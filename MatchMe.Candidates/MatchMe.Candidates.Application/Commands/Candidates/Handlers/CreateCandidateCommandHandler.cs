using MatchMe.Candidates.Application.Commands.Candidates;
using MatchMe.Candidates.Application.Services;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Entities.Extensions;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Candidates.Application.Mapping;
using MatchMe.Candidates.Integration.Publishers;

namespace MatchMe.Candidates.Application.Commands.Handlers
{
    public class CreateCandidateCommandHandler : ICommandHandler<CreateCandidateCommand, long>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICandidateReadService _candidateReadService;
        private readonly ICandidateCreatedPublisher _publisher;
        public CreateCandidateCommandHandler(ICandidateRepository CandidateRepository, ICandidateReadService CandidateReadService,
            ICandidateCreatedPublisher Publisher)
        {
            _candidateRepository = CandidateRepository;
            _candidateReadService = CandidateReadService;
            _publisher = Publisher;
        }

        public async Task<long> Handle(CreateCandidateCommand Request, CancellationToken CancellationToken)
        {
            if (await _candidateReadService.ExistsByFiscalNumberAsync(Request.FiscalNumber))
                throw new ApplicationEntityAlreadyExistsException(nameof(Candidate),"Fiscal Number", Request.FiscalNumber);


            var candidate = Candidate.Create(Request.FirstName, Request.LastName, Request.DateOfBirth, 
                new AddressObject(Request.Address.Street, Request.Address.City, Request.Address.State, Request.Address.PostCode, Request.Address.Country),
                Request.Gender, Request.MaritalStatus, Request.Nationality, Request.MobilePhone,
                Request.Email, Request.FiscalNumber, Request.CitizenCardNumber);

            candidate.AddSkills(Request.Skills.AsCandidateSkill());
            candidate.AddExperiences(Request.Experiences.AsCandidateExperience());
            candidate.AddEducations(Request.Educations.AsCandidateEducation());

            await _candidateRepository.AddAsync(candidate, CancellationToken);

            _publisher.SendMessage(candidate.AsCandidateCreatedMessageDto());

            return candidate.Id;
        }
    }
}

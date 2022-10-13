using MatchMe.Candidates.Application.Commands.Candidates;
using MatchMe.Candidates.Application.Dto.CandidatesExperience.Extensions;
using MatchMe.Candidates.Application.Dto.CandidatesEducation.Extensions;
using MatchMe.Candidates.Application.Dto.CandidatesSkill.Extensions;
using MatchMe.Candidates.Application.Services;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Entities.Extensions;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Candidates.Integration.Publishers;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Exceptions;

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
            if (Request.CandidateCreateDto is null)
                throw new ApplicationEntityInvalidException(nameof(Candidate));

            if (await _candidateReadService.ExistsByFiscalNumberAsync(Request.CandidateCreateDto.FiscalNumber))
                throw new ApplicationEntityAlreadyExistsException(nameof(Candidate),"Fiscal Number", Request.CandidateCreateDto.FiscalNumber);

            var candidateCreateDto = Request.CandidateCreateDto;

            var candidate = Candidate.Create(candidateCreateDto.FirstName, candidateCreateDto.LastName, candidateCreateDto.DateOfBirth, 
                new AddressObject(candidateCreateDto.Address.Street, candidateCreateDto.Address.City, candidateCreateDto.Address.State, candidateCreateDto.Address.PostCode, candidateCreateDto.Address.Country),
                candidateCreateDto.Gender, candidateCreateDto.MaritalStatus, candidateCreateDto.Nationality, candidateCreateDto.MobilePhone,
                candidateCreateDto.Email, candidateCreateDto.FiscalNumber, candidateCreateDto.CitizenCardNumber);

            candidate.AddSkills(candidateCreateDto.Skills.AsCandidateSkill());
            candidate.AddExperiences(candidateCreateDto.Experiences.AsCandidateExperience());
            candidate.AddEducations(candidateCreateDto.Educations.AsCandidateEducation());

            await _candidateRepository.AddAsync(candidate, CancellationToken);

            _ = _publisher.SendAsync(candidate.AsCandidateCreatedDto(), CancellationToken);

            return candidate.Id;
        }
    }
}

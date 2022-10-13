using MatchMe.Candidates.Application.Commands.Candidates;
using MatchMe.Candidates.Application.Mapping;
using MatchMe.Candidates.Application.Services;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Candidates.Application.Commands.Handlers
{
    public class UpdateCandidateCommandHandler : ICommandHandler<UpdateCandidateCommand, bool>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICandidateReadService _candidateReadService;

        public UpdateCandidateCommandHandler(ICandidateRepository CandidateRepository, ICandidateReadService CandidateReadService)
        {
            _candidateRepository = CandidateRepository;
            _candidateReadService = CandidateReadService;
        }
        public async Task<bool> Handle(UpdateCandidateCommand Request, CancellationToken CancellationToken)
        {
            var candidateEf = await _candidateRepository.GetAsync(Request.Id, CancellationToken);

            if (candidateEf == null)
                throw new ApplicationEntityNotFoundException(nameof(Candidate), Request.Id.ToString());

            candidateEf.Update(Request.FirstName, Request.LastName, Request.DateOfBirth,new AddressObject(Request.Address.Street, Request.Address.City, Request.Address.State,
                Request.Address.PostCode, Request.Address.Country), Request.Gender, Request.MaritalStatus, Request.Nationality, Request.MobilePhone, Request.Email,
                Request.FiscalNumber, Request.CitizenCardNumber,
                Request.Skills.AsCandidateSkill(),
                Request.Experiences.AsCandidateExperience(),
                Request.Educations.AsCandidateEducation());

            await _candidateRepository.UpdateAsync(candidateEf, CancellationToken);

            return true;
        }
    }
}

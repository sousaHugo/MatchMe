using MatchMe.Candidates.Application.Commands.Candidates;
using MatchMe.Candidates.Application.Dto.CandidatesEducation.Extensions;
using MatchMe.Candidates.Application.Dto.CandidatesExperience.Extensions;
using MatchMe.Candidates.Application.Dto.CandidatesSkill.Extensions;
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
            if (Request.CandidateUpdateDto is null)
                throw new ApplicationEntityInvalidException(nameof(Candidate));

            var candidateEf = await _candidateRepository.GetAsync(Request.CandidateUpdateDto.Id, CancellationToken);

            if (candidateEf == null)
                throw new ApplicationEntityNotFoundException(nameof(Candidate), Request.CandidateUpdateDto.Id.ToString());

            var candidateUpdateDto = Request.CandidateUpdateDto;

            candidateEf.Update(candidateUpdateDto.FirstName, candidateUpdateDto.LastName, candidateUpdateDto.DateOfBirth,new AddressObject(candidateUpdateDto.Address.Street, candidateUpdateDto.Address.City, candidateUpdateDto.Address.State, 
                candidateUpdateDto.Address.PostCode, candidateUpdateDto.Address.Country), candidateUpdateDto.Gender, candidateUpdateDto.MaritalStatus, candidateUpdateDto.Nationality, candidateUpdateDto.MobilePhone, candidateUpdateDto.Email,
                candidateUpdateDto.FiscalNumber, candidateUpdateDto.CitizenCardNumber, 
                candidateUpdateDto.Skills.AsCandidateSkill(),
                candidateUpdateDto.Experiences.AsCandidateExperience(),
                candidateUpdateDto.Educations.AsCandidateEducation());

            await _candidateRepository.UpdateAsync(candidateEf, CancellationToken);

            return true;
        }
    }
}

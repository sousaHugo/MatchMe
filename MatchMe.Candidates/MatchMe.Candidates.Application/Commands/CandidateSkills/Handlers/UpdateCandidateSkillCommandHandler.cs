using MatchMe.Candidates.Application.Services;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Candidates.Application.Commands.CandidateSkills.Handlers
{
    public class UpdateCandidateSkillCommandHandler : ICommandHandler<UpdateCandidateSkillCommand, long>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICandidateSkillReadService _candidateSkillReadService;
        public UpdateCandidateSkillCommandHandler(ICandidateRepository CandidateRepository, ICandidateSkillReadService CandidateSkillReadService)
        {
            _candidateRepository = CandidateRepository;
            _candidateSkillReadService = CandidateSkillReadService;
        }
        public async Task<long> Handle(UpdateCandidateSkillCommand Request, CancellationToken CancellationToken)
        {
            if (Request.CandidateSkillUpdateDto is null)
                throw new ApplicationEntityInvalidException(nameof(CandidateSkill));

            var skill = await _candidateSkillReadService.GetByIdAsync(Request.CandidateSkillUpdateDto.Id);

            if (skill is null)
                throw new ApplicationEntityNotFoundException(nameof(CandidateSkill), Request.CandidateSkillUpdateDto.Name);

            var candidateEf = await _candidateRepository.GetAsync(skill.CandidateId, CancellationToken);

            var newCandidateSkill = new CandidateSkill(Request.CandidateSkillUpdateDto.Id, Request.CandidateSkillUpdateDto.Name, Request.CandidateSkillUpdateDto.Experience, Request.CandidateSkillUpdateDto.Level);

            candidateEf.UpdateSkill(newCandidateSkill);

            await _candidateRepository.UpdateAsync(candidateEf, CancellationToken);

            return newCandidateSkill.Id;
        }
    }
}

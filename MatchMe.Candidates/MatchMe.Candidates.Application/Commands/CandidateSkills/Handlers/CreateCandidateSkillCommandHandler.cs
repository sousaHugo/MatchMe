using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Candidates.Application.Commands.CandidateSkills.Handlers
{
    public class CreateCandidateSkillCommandHandler : ICommandHandler<CreateCandidateSkillCommand, long>
    {
        private readonly ICandidateRepository _candidateRepository;
        public CreateCandidateSkillCommandHandler(ICandidateRepository CandidateRepository)
        {
            _candidateRepository = CandidateRepository;
        }
        public async Task<long> Handle(CreateCandidateSkillCommand Request, CancellationToken CancellationToken)
        {
            if (Request.CandidateSkillCreateDto is null)
                throw new ApplicationEntityInvalidException(nameof(CandidateSkill));

            var candidateEf = await _candidateRepository.GetAsync(Request.CandidateSkillCreateDto.CandidateId, CancellationToken);

            var newCandidateSkill = CandidateSkill.Create(Request.CandidateSkillCreateDto.Name, Request.CandidateSkillCreateDto.Experience, Request.CandidateSkillCreateDto.Level);

            candidateEf.AddSkill(newCandidateSkill);

            await _candidateRepository.UpdateAsync(candidateEf, CancellationToken);

            return newCandidateSkill.Id;
        }
    }
}

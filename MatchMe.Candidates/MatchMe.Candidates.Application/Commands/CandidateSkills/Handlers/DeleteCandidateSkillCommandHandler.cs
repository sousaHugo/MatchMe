using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Exceptions;
using MediatR;

namespace MatchMe.Candidates.Application.Commands.CandidateSkills.Handlers
{
    public class DeleteCandidateSkillCommandHandler : ICommandHandler<DeleteCandidateSkillCommand, Unit>
    {
        private readonly ICandidateRepository _candidateRepository;
        public DeleteCandidateSkillCommandHandler(ICandidateRepository CandidateRepository)
        {
            _candidateRepository = CandidateRepository;
        }
        public async Task<Unit> Handle(DeleteCandidateSkillCommand Request, CancellationToken CancellationToken)
        {
            if (Request is null)
                throw new ApplicationEntityInvalidException(nameof(CandidateSkill));

            var candidateEf = await _candidateRepository.GetAsync(Request.CandidateId, CancellationToken);
            candidateEf.RemoveSkill(Request.SkillId);
           
            await _candidateRepository.UpdateAsync(candidateEf, CancellationToken);
            
            return new Unit();
        }
    }
}

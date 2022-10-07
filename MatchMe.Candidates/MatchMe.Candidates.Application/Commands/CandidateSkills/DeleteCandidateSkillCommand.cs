using MediatR;

namespace MatchMe.Candidates.Application.Commands.CandidateSkills
{
    public record DeleteCandidateSkillCommand(long CandidateId, long SkillId) : IRequest<Unit>;
}

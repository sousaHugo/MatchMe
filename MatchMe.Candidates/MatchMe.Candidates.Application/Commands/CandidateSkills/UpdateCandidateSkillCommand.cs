using MatchMe.Candidates.Application.Dto;
using MediatR;

namespace MatchMe.Candidates.Application.Commands.CandidateSkills
{
    public record UpdateCandidateSkillCommand(CandidateSkillUpdateDto CandidateSkillUpdateDto) : IRequest<long>;
}

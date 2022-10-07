using MatchMe.Candidates.Application.Dto;
using MediatR;

namespace MatchMe.Candidates.Application.Commands.CandidateSkills
{
    public record CreateCandidateSkillCommand(CandidateSkillCreateDto CandidateSkillCreateDto) : IRequest<long>;
}

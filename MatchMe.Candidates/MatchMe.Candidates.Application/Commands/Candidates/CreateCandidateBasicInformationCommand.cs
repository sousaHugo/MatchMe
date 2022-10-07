using MatchMe.Candidates.Application.Dto.Candidates;
using MediatR;

namespace MatchMe.Candidates.Application.Commands.Candidates
{
    public record CreateCandidateBasicInformationCommand(CandidateCreateDto CandidateCreateDto) : IRequest<long>;
}

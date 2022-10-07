using MediatR;

namespace MatchMe.Candidates.Application.Commands.Candidates
{
    public record DeleteCandidateCommand(long Id) : IRequest<Unit>;
}

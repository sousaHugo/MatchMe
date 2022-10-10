using MediatR;

namespace MatchMe.Opportunities.Application.Commands
{
    public record DeleteOpportunityCommand(long Id) : IRequest<Unit>;
}

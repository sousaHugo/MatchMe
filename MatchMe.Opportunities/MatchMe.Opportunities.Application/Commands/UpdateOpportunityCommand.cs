using MatchMe.Opportunities.Application.Dto.Opportunity;
using MediatR;

namespace MatchMe.Opportunities.Application.Commands
{
    public record UpdateOpportunityCommand(OpportunityUpdateWithDetailsDto OpportunityUpdateDto) : IRequest<long>;
}

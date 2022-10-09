using MatchMe.Opportunities.Application.Dto.Opportunity;
using MediatR;

namespace MatchMe.Opportunities.Infrastructure.Queries
{
    public class GetOpportunityQuery : IRequest<OpportunityBaseDto>
    {
        public long Id { get; set; }
    }
}

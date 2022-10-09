using MatchMe.Opportunities.Application.Dto;
using MediatR;

namespace MatchMe.Opportunities.Infrastructure.Queries
{
    public class GetOpportunityQuery : IRequest<OpportunityBaseDto>
    {
        public long Id { get; set; }
    }
}

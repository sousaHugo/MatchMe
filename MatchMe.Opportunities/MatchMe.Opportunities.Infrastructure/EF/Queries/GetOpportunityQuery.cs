using MatchMe.Opportunities.Application.Dto;
using MediatR;

namespace MatchMe.Opportunities.Infrastructure.Queries
{
    public class GetOpportunityQuery : IRequest<OpportunityDto>
    {
        public Guid Id { get; set; }
    }
}

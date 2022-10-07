using MatchMe.Opportunities.Application.Dto;
using MediatR;

namespace MatchMe.Opportunities.Infrastructure.Queries
{
    public class SearchOpportunitiesQuery : IRequest<IEnumerable<OpportunityDto>>
    {
        public string Search_Phrase { get; set; }
    }
}

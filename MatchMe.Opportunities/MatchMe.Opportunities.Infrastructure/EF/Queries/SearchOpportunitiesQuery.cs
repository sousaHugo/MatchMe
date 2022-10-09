using MatchMe.Opportunities.Application.Dto.Opportunity;
using MediatR;

namespace MatchMe.Opportunities.Infrastructure.Queries
{
    public class SearchOpportunitiesQuery : IRequest<IEnumerable<OpportunityBaseDto>>
    {
        public string Search_Phrase { get; set; }
    }
}

using Mapster;
using MatchMe.Common.Shared.Queries;
using MatchMe.Opportunities.Application.Dto;
using MatchMe.Opportunities.Infrastructure.EF.Contexts;
using MatchMe.Opportunities.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Opportunities.Infrastructure.Queries.Handlers
{
    internal sealed class SearchOpportunitiesHandler : IQueryHandler<SearchOpportunitiesQuery, IEnumerable<OpportunityDto>>
    {
        private readonly DbSet<OpportunityReadModel> _opportunityReadModel;

        public SearchOpportunitiesHandler(ReadDbContext DbContext) => _opportunityReadModel = DbContext.Opportunity;

        public async Task<IEnumerable<OpportunityDto>> Handle(SearchOpportunitiesQuery Request, CancellationToken CancellationToken)
        {
            var dbQuery = _opportunityReadModel
                .Include(a => a.Skills)
                .AsQueryable();

            if (Request.Search_Phrase is not null)
            {
                dbQuery = dbQuery.Where(a => Microsoft.EntityFrameworkCore.EF.Functions.ILike(a.Title, $"%{Request.Search_Phrase}%"));
            }

            return await dbQuery.Select(a => a.Adapt<OpportunityDto>()).AsNoTracking().ToListAsync();
        }
    }
}

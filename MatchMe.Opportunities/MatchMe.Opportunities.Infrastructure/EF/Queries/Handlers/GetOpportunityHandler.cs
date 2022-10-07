using Mapster;
using MatchMe.Common.Shared.Queries;
using MatchMe.Opportunities.Application.Dto;
using MatchMe.Opportunities.Infrastructure.EF.Contexts;
using MatchMe.Opportunities.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Opportunities.Infrastructure.Queries.Handlers
{
    internal sealed class GetOpportunityHandler : IQueryHandler<GetOpportunityQuery, OpportunityDto>
    {
        private readonly DbSet<OpportunityReadModel> _opportunityReadModel;

        public GetOpportunityHandler(ReadDbContext DbContext) => _opportunityReadModel = DbContext.Opportunity;

        public Task<OpportunityDto> Handle(GetOpportunityQuery Request, CancellationToken CancellationToken)
        => _opportunityReadModel
            .Include(a => a.Skills)
            .Where(a => a.Id == Request.Id)
            .Select(a => a.Adapt<OpportunityDto>())
            .AsNoTracking()
            .SingleOrDefaultAsync();

    }
}

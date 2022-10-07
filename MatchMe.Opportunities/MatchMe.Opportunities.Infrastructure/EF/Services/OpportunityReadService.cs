using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Infrastructure.EF.Contexts;
using MatchMe.Opportunities.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Opportunities.Infrastructure.EF.Services
{
    internal class OpportunityReadService : IOpportunityReadService
    {
        private readonly DbSet<OpportunityReadModel> _opportunity;
        public OpportunityReadService(ReadDbContext DbContext) => _opportunity = DbContext.Opportunity;

        public Task<bool> ExistsByTitleAsync(string Title)
            => _opportunity.AnyAsync(a => a.Title == Title);

    }
}

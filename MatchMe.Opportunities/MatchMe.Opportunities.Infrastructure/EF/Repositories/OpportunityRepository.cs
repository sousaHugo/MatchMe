using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Repositories;
using MatchMe.Opportunities.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Opportunities.Infrastructure.EF.Repositories
{
    internal sealed class OpportunityRepository : IOpportunityRepository
    {
        private readonly DbSet<Opportunity> _opportunityDbSet;
        private readonly WriteDbContext _writeDbContext;

        public OpportunityRepository(WriteDbContext WriteDbContext)
        {
            _opportunityDbSet = WriteDbContext.Opportunity;
            _writeDbContext = WriteDbContext;
        }

        public Task<Opportunity> GetAsync(Identity Id, CancellationToken CancellationToken = default)
           => _opportunityDbSet.Include(a => a.Skills).SingleOrDefaultAsync(a => a.Id == Id, CancellationToken);

        public async Task AddAsync(Opportunity Opportunity, CancellationToken CancellationToken = default)
        {
            await _opportunityDbSet.AddAsync(Opportunity, CancellationToken);
            await _writeDbContext.SaveChangesAsync(CancellationToken);
        }
        public async Task UpdateAsync(Opportunity Opportunity, CancellationToken CancellationToken = default)
        {
            _opportunityDbSet.Update(Opportunity);
            await _writeDbContext.SaveChangesAsync(CancellationToken);
        }

        public async Task DeleteAsync(Opportunity Opportunity, CancellationToken CancellationToken = default)
        {
            _opportunityDbSet.Remove(Opportunity);
            await _writeDbContext.SaveChangesAsync(CancellationToken);
        }
    }
}

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

        public Task<Opportunity> GetAsync(Identity Id)
           => _opportunityDbSet.Include("_skills").SingleOrDefaultAsync(a => a.Id == Id);

        public async Task AddAsync(Opportunity Opportunity)
        {
            await _opportunityDbSet.AddAsync(Opportunity);
            await _writeDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Opportunity Opportunity)
        {
            _opportunityDbSet.Update(Opportunity);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Opportunity Opportunity)
        {
            _opportunityDbSet.Remove(Opportunity);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}

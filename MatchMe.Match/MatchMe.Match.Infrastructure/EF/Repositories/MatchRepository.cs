using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Match.Domain.Repositories;
using MatchMe.Match.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Match.Infrastructure.EF.Repositories
{
    internal sealed class MatchRepository : IMatchRepository
    {
        private readonly DbSet<Domain.Entities.Match> _matchDbSet;
        private readonly WriteDbContext _writeDbContext;

        public MatchRepository(WriteDbContext WriteDbContext)
        {
            _matchDbSet = WriteDbContext.Match;
            _writeDbContext = WriteDbContext;
        }

        public Task<Domain.Entities.Match> GetAsync(Identity Id, CancellationToken CancellationToken = default)
           => _matchDbSet.SingleOrDefaultAsync(a => a.Id == Id, CancellationToken);

        public async Task AddAsync(Domain.Entities.Match Opportunity, CancellationToken CancellationToken = default)
        {
            await _matchDbSet.AddAsync(Opportunity, CancellationToken);
            await _writeDbContext.SaveChangesAsync(CancellationToken);
        }
        public async Task UpdateAsync(Domain.Entities.Match Opportunity, CancellationToken CancellationToken = default)
        {
            _matchDbSet.Update(Opportunity);
            await _writeDbContext.SaveChangesAsync(CancellationToken);
        }

        public async Task DeleteAsync(Domain.Entities.Match Opportunity, CancellationToken CancellationToken = default)
        {
            _matchDbSet.Remove(Opportunity);
            await _writeDbContext.SaveChangesAsync(CancellationToken);
        }
    }
}

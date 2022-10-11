using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Match.Domain.Repositories
{
    public interface IMatchRepository
    {
        Task<Entities.Match> GetAsync(Identity Id, CancellationToken CancellationToken = default);
        Task AddAsync(Entities.Match Opportunity, CancellationToken CancellationToken = default);
        Task UpdateAsync(Entities.Match Opportunity, CancellationToken CancellationToken = default);
        Task DeleteAsync(Entities.Match Opportunity, CancellationToken CancellationToken = default);
    }
}

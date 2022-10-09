using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Opportunities.Domain.Entities;

namespace MatchMe.Opportunities.Domain.Repositories
{
    public interface IOpportunityRepository
    {
        Task<Opportunity> GetAsync(Identity Id, CancellationToken CancellationToken = default);
        Task AddAsync(Opportunity Opportunity, CancellationToken CancellationToken = default);
        Task UpdateAsync(Opportunity Opportunity, CancellationToken CancellationToken = default);
        Task DeleteAsync(Opportunity Opportunity, CancellationToken CancellationToken = default);
    }
}

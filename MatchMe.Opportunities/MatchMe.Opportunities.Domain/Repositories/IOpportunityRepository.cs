using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Opportunities.Domain.Entities;

namespace MatchMe.Opportunities.Domain.Repositories
{
    public interface IOpportunityRepository
    {
        Task<Opportunity> GetAsync(Identity Id);
        Task AddAsync(Opportunity Opportunity);
        Task UpdateAsync(Opportunity Opportunity);
        Task DeleteAsync(Opportunity Opportunity);
    }
}

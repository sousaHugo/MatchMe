using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.ValueObjects;

namespace MatchMe.Opportunities.Domain.Repositories
{
    public interface IOpportunityRepository
    {
        Task<Opportunity> GetAsync(OpportunityId Id);
        Task AddAsync(Opportunity Opportunity);
        Task UpdateAsync(Opportunity Opportunity);
        Task DeleteAsync(Opportunity Opportunity);
    }
}

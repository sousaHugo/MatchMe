using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.ValueObjects;

namespace MatchMe.Opportunities.Domain.Factories
{
    public interface IOpportunityFactory
    {
        Opportunity Create(OpportunityId OpportunityId, OpportunityName OpportunityName, OpportunityDescription OpportunityDescription);
        Opportunity CreateWithSkills(OpportunityId OpportunityId, OpportunityName OpportunityName, OpportunityDescription OpportunityDescription, IEnumerable<OpportunitySkill> Skills);
    }
}

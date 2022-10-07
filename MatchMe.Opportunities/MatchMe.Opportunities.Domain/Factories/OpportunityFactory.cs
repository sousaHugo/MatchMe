using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.ValueObjects;

namespace MatchMe.Opportunities.Domain.Factories
{
    public sealed class OpportunityFactory : IOpportunityFactory
    {
        public Opportunity Create(OpportunityId OpportunityId, OpportunityName OpportunityName, OpportunityDescription OpportunityDescription)
        => new(OpportunityId, OpportunityName, OpportunityDescription);

        public Opportunity CreateWithSkills(OpportunityId OpportunityId, OpportunityName OpportunityName, OpportunityDescription OpportunityDescription, IEnumerable<OpportunitySkill> Skills)
        {
            var opportunity = Create(OpportunityId, OpportunityName, OpportunityDescription);

            opportunity.AddSkills(Skills);

            return opportunity;
        }
    }
}

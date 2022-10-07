using MatchMe.Common.Shared.Domain;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.ValueObjects;

namespace MatchMe.Opportunities.Domain.Events
{
    public class OpportunitySkillAddedEvent : DomainEvent
    {
        public OpportunitySkillAddedEvent(Opportunity Opportunity, OpportunitySkill OpportunitySkill)
        {

        }
    }
}

using MatchMe.Common.Shared.Domain;
using MatchMe.Opportunities.Domain.Entities;
using OpportunitySkill = MatchMe.Opportunities.Domain.Entities.OpportunitySkill;

namespace MatchMe.Opportunities.Domain.Events
{
    public class OpportunitySkillUpdateEvent : DomainEvent
    {
        public OpportunitySkillUpdateEvent(Opportunity Opportunity, OpportunitySkill OpportunitySkill)
        {

        }
    }
}

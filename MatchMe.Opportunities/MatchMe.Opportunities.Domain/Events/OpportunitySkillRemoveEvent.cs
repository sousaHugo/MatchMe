using MatchMe.Common.Shared.Domain;
using MatchMe.Opportunities.Domain.Entities;
using OpportunitySkill = MatchMe.Opportunities.Domain.Entities.OpportunitySkill;

namespace MatchMe.Opportunities.Domain.Events
{
    public class OpportunitySkillRemoveEvent : DomainEvent
    {
        public OpportunitySkillRemoveEvent(Opportunity Opportunity, OpportunitySkill OpportunitySkill)
        {

        }
    }
}

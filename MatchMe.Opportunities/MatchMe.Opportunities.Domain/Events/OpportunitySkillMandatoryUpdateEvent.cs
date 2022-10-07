using MatchMe.Common.Shared.Domain;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.ValueObjects;

namespace MatchMe.Opportunities.Domain.Events
{
    public class OpportunitySkillMandatoryUpdateEvent : DomainEvent
    {
        public OpportunitySkillMandatoryUpdateEvent(Opportunity Opportunity, OpportunitySkill OpportunitySkill)
        {

        }
    }
}

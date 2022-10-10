using MatchMe.Common.Shared.Domain;
using MatchMe.Opportunities.Domain.Entities;
using OpportunitySkill = MatchMe.Opportunities.Domain.Entities.OpportunitySkill;

namespace MatchMe.Opportunities.Domain.Events
{
    public class OpportunitySkillUpdateEvent : DomainEvent
    {
        private readonly OpportunitySkill _opportunitySkill;
        private readonly string _ooportunityTitle;
        public OpportunitySkill OpportunitySkill => _opportunitySkill;
        public string OpportunityTitle => _ooportunityTitle;
        public OpportunitySkillUpdateEvent(OpportunitySkill OpportunitySkill, string OpportunityTitle)
        {
            _opportunitySkill = OpportunitySkill;
            _ooportunityTitle = OpportunityTitle;
        }
    }
}

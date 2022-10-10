using MatchMe.Common.Shared.Domain;
using OpportunitySkill = MatchMe.Opportunities.Domain.Entities.OpportunitySkill;

namespace MatchMe.Opportunities.Domain.Events
{
    public class OpportunitySkillRemoveEvent : DomainEvent
    {
        private readonly OpportunitySkill _opportunitySkill;
        private readonly string _ooportunityTitle;
        public OpportunitySkill OpportunitySkill => _opportunitySkill;
        public string OpportunityTitle => _ooportunityTitle;
        public OpportunitySkillRemoveEvent(OpportunitySkill OpportunitySkill, string OpportunityTitle)
        {
            _opportunitySkill = OpportunitySkill;
            _ooportunityTitle = OpportunityTitle;
        }
    }
}

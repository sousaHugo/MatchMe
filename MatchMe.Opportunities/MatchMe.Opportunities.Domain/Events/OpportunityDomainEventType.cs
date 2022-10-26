namespace MatchMe.Opportunities.Domain.Events
{
    public static class OpportunityDomainEventType
    {
        public static readonly string UpdatedDomainEvent = "OpportunityUpdatedDomainEvent";
        public static readonly string OpportunityCreatedDomainEvent = "OpportunityCreatedDomainEvent";
        public static readonly string OpportunityAddSkillDomainEvent = "OpportunityAddSkillDomainEvent";
        public static readonly string OpportunityUpdateSkillDomainEvent = "OpportunityUpdateSkillDomainEvent";
        public static readonly string OpportunityRemoveSkillDomainEvent = "OpportunityRemoveSkillDomainEvent";
    }
}

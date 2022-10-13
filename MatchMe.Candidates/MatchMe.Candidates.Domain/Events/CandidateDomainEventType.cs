namespace MatchMe.Candidates.Domain.Events
{
    public static class CandidateDomainEventTypes
    {
        public static readonly string CandidateUpdatedDomainEvent = "CandidateUpdatedDomainEvent";
        public static readonly string CandidateCreatedDomainEvent = "CandidateCreatedDomainEvent";
        public static readonly string CandidateAddSkillDomainEvent = "CandidateAddSkillDomainEvent";
        public static readonly string CandidateUpdateSkillDomainEvent = "CandidateUpdateSkillDomainEvent";
        public static readonly string CandidateRemoveSkillDomainEvent = "CandidateRemoveSkillDomainEvent";
    }
}

using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain;

namespace MatchMe.Candidates.Domain.Events
{
    public class CandidateSkillUpdatedEvent : DomainEvent
    {
        public CandidateSkillUpdatedEvent(CandidateSkill CandidateSkill)
        {
            this.CandidateSkill = CandidateSkill;
        }
        public CandidateSkill CandidateSkill { get; }
    }
}

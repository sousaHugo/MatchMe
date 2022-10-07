using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain;

namespace MatchMe.Candidates.Domain.Events
{
    public class CandidateSkillAddedEvent : DomainEvent
    {
        public CandidateSkillAddedEvent(CandidateSkill CandidateSkill)
        {
            this.CandidateSkill = CandidateSkill;
        }
        public CandidateSkill CandidateSkill { get; }
    }
}

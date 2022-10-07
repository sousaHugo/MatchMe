using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain;

namespace MatchMe.Candidates.Domain.Events
{
    public class CandidateCreatedEvent : DomainEvent
    {
        public CandidateCreatedEvent(Candidate Candidate)
        {
            this.Candidate = Candidate;
        }
        public Candidate Candidate { get; }
    }
}

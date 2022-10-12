using IdGen;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain;

namespace MatchMe.Candidates.Domain.Events
{
    public class CandidateDomainEvent : DomainEvent
    {
        public string Type { get; protected set; }

        public CandidateDomainEvent(Candidate Candidate, string EventType)
        {
            this.Candidate = Candidate;
            Type = EventType;
        }
        public Candidate Candidate { get; protected set; }

       
    }
}

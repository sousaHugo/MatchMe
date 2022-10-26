using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Events.Models;
using MatchMe.Candidates.Domain.Mapping;
using MatchMe.Common.Shared.Domain;

namespace MatchMe.Candidates.Domain.Events
{
    public class CandidateDomainEvent : DomainEvent
    {
        public string Type { get; protected set; }

        public CandidateDomainEvent(Candidate Candidate, string EventType)
        {
            this.Candidate = Candidate.AsCandidateDEModel();
            Type = EventType;
        }
        public CandidateDEModel Candidate { get; protected set; }
    }
}

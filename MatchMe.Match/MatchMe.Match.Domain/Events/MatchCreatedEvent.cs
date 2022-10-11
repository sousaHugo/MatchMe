using MatchMe.Common.Shared.Domain;

namespace MatchMe.Match.Domain.Events
{
    public class MatchCreatedEvent : DomainEvent
    {
        private readonly Entities.Match _match;
        public MatchCreatedEvent(Entities.Match Match)
        {
            _match = Match;
        }
        public Entities.Match Match => _match;
    }
}

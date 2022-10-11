using MatchMe.Common.Shared.Domain;

namespace MatchMe.Match.Domain.Events
{
    public class MatchUpdatedEvent : DomainEvent
    {
        private readonly Entities.Match _match;
        public MatchUpdatedEvent(Entities.Match Match)
        {
            _match = Match;
        }
        public Entities.Match Match => _match;
    }
}

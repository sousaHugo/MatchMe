using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Common.Shared.Domain
{
    public abstract class AggregateRoot<T> : BaseEntity<Identity>
    {
        public int Version { get; protected set; }

        public IEnumerable<DomainEvent> Events => _events;

        private readonly List<DomainEvent> _events = new();

        private bool _versionIncremented;

        protected void IncrementVersion()
        {
            if (_versionIncremented)
                return;

            Version++;
            _versionIncremented = true;
        }
        public void ClearEvents() => _events.Clear();
        protected void AddEvent(DomainEvent @event)
        {
            if (!_versionIncremented && !_events.Any())
            {
                Version++;
                _versionIncremented = true;

                _events.Add(@event);
            }
        }
    }
}

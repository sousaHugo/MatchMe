using IdGen;
using MatchMe.Common.Shared.MongoDb;
using MediatR;

namespace MatchMe.Common.Shared.Domain
{
    public abstract class DomainEvent : INotification, IMongoEntity
    {
        protected DomainEvent()
        {
            DateOccurred = DateTimeOffset.UtcNow;
        }
        public bool IsPublished { get; set; }
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;

        public long Id => new IdGenerator(0).CreateId();
    }
}

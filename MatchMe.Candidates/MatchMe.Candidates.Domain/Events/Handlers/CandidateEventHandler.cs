using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.MongoDb;
using MediatR;

namespace MatchMe.Candidates.Domain.Events.Handlers
{
    public class CandidateEventHandler : INotificationHandler<CandidateDomainEvent>
    {
        private readonly IMongoRepository<DomainEvent> _mongoRepository;
        public CandidateEventHandler(IMongoRepository<DomainEvent> MongoRepository)
        {
            _mongoRepository = MongoRepository;
        }
        public Task Handle(CandidateDomainEvent Event, CancellationToken CancellationToken)
        {
           return _mongoRepository.CreateAsync(Event);
        }


    }
}

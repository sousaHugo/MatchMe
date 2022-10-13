using MassTransit;
using MatchMe.Common.Shared.Integration.Candidates;
using MatchMe.Common.Shared.MongoDb;

namespace MatchMe.Match.Integration.Consumers.Candidates
{
    public class CandidateCreatedConsumer : IConsumer<CandidateCreatedDto>
    {
        private readonly IMongoRepository<CandidateCreatedDto> _mongoRepository;

        public CandidateCreatedConsumer(IMongoRepository<CandidateCreatedDto> MongoRepository)
        {
            _mongoRepository = MongoRepository;
        }
        public async Task Consume(ConsumeContext<CandidateCreatedDto> Context)
        {
            var message = Context.Message;

            await _mongoRepository.CreateAsync(message);
        }
    }
}

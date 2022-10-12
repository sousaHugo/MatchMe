using MassTransit;
using MatchMe.Common.Shared.Integration.Opportunities;
using MatchMe.Common.Shared.MongoDb;
using Microsoft.Extensions.Logging;

namespace MatchMe.Match.Integration.Consumers.Opportunities
{
    public class OpportunityCreatedConsumer : IConsumer<OpportunityCreatedDto>
    {
        private readonly ILogger<OpportunityCreatedConsumer> _logger;
        private readonly IMongoRepository<OpportunityCreatedDto> _mongoRepository;

        public OpportunityCreatedConsumer(ILogger<OpportunityCreatedConsumer> Logger, IMongoRepository<OpportunityCreatedDto> MongoRepository)
        {
            _logger = Logger;
            _mongoRepository = MongoRepository;
        }
        public async Task Consume(ConsumeContext<OpportunityCreatedDto> Context)
        {
            var message = Context.Message;

            await _mongoRepository.CreateAsync(message);
        }
    }
}

using MassTransit;
using MatchMe.Common.Shared.Dtos.Integration.Opportunities;
using Microsoft.Extensions.Logging;

namespace MatchMe.Match.Integration.Consumers.Opportunities
{
    public class OpportunityCreatedConsumer : IConsumer<OpportunityCreatedDto>
    {
        private readonly ILogger<OpportunityCreatedConsumer> _logger;
        public OpportunityCreatedConsumer(ILogger<OpportunityCreatedConsumer> Logger) => _logger = Logger;
        public async Task Consume(ConsumeContext<OpportunityCreatedDto> Context)
        {
            var message = Context.Message;

            await Task.Run(() =>
            {
                _logger.LogInformation("Consumer: Opportunity was Created: {0}", message.OpportunityId);
            });
        }
    }
}

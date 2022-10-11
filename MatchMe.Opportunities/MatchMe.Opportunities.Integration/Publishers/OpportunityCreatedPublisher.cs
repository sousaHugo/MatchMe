using MassTransit;
using MatchMe.Common.Shared.Dtos.Integration.Opportunities;

namespace MatchMe.Opportunities.Integration.Publishers
{
    public class OpportunityCreatedPublisher : IOpportunityCreatedPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public OpportunityCreatedPublisher(IPublishEndpoint PublishEndpoint) => _publishEndpoint = PublishEndpoint;
        public Task SendAsync(OpportunityCreatedDto OpportunityCreatedDto, CancellationToken CancellationToken = default)
        {
            _publishEndpoint.Publish(OpportunityCreatedDto, CancellationToken);

            return Task.CompletedTask;
        }
    }
}

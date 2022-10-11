using MatchMe.Common.Shared.Dtos.Integration.Opportunities;
using MatchMe.Opportunities.Integration.Publishers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MatchMe.Opportunities.Domain.Events.Handlers
{
    public class OpportunityEventHandler : INotificationHandler<OpportunityCreateEvent>,
                                           INotificationHandler<OpportunityUpdateEvent>
    {
        private readonly ILogger<OpportunityEventHandler> _logger;
        private readonly IOpportunityCreatedPublisher _publisher;
        public OpportunityEventHandler(ILogger<OpportunityEventHandler> logger, IOpportunityCreatedPublisher Publisher)
        {
            _logger = logger;
            _publisher = Publisher;
        }
        public Task Handle(OpportunityCreateEvent Event, CancellationToken CancellationToken)
        {
            _logger.LogInformation("Opportunity was Created: {0}", Event.Opportunity.Title);
            _publisher.SendAsync(new OpportunityCreatedDto(Event.Opportunity.Id));
            return Task.CompletedTask;
        }
        public Task Handle(OpportunityUpdateEvent Event, CancellationToken CancellationToken)
        {
            _logger.LogInformation("Opportunity was updated: {0}", Event.Opportunity.Title);
            return Task.CompletedTask;
        }


    }
}

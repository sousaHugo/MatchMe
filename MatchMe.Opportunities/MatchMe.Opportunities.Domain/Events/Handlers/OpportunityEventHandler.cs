using MediatR;
using Microsoft.Extensions.Logging;

namespace MatchMe.Opportunities.Domain.Events.Handlers
{
    public class OpportunityEventHandler : INotificationHandler<OpportunityCreateEvent>,
                                           INotificationHandler<OpportunityUpdateEvent>
    {
        private readonly ILogger<OpportunityEventHandler> _logger;
       
        public OpportunityEventHandler(ILogger<OpportunityEventHandler> Logger)
        {
            _logger = Logger;
        }
        public Task Handle(OpportunityCreateEvent Event, CancellationToken CancellationToken)
        {
            _logger.LogInformation("Opportunity was Created: {0}", Event.Opportunity.Title);
           
            return Task.CompletedTask;
        }
        public Task Handle(OpportunityUpdateEvent Event, CancellationToken CancellationToken)
        {
            _logger.LogInformation("Opportunity was updated: {0}", Event.Opportunity.Title);
            return Task.CompletedTask;
        }


    }
}

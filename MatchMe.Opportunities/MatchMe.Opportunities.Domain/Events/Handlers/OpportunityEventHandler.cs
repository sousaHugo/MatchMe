using MediatR;
using Microsoft.Extensions.Logging;

namespace MatchMe.Opportunities.Domain.Events.Handlers
{
    public class OpportunityEventHandler : INotificationHandler<OpportunityDomainEvent>
    {
        private readonly ILogger<OpportunityEventHandler> _logger;
       
        public OpportunityEventHandler(ILogger<OpportunityEventHandler> Logger)
        {
            _logger = Logger;
        }
        public Task Handle(OpportunityDomainEvent Event, CancellationToken CancellationToken)
        {
            _logger.LogInformation("Opportunity was Created: {0}", Event.Opportunity.Title);
           
            return Task.CompletedTask;
        }
    }
}

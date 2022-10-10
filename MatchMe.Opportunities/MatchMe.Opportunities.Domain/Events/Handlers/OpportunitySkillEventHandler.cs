using MediatR;
using Microsoft.Extensions.Logging;

namespace MatchMe.Opportunities.Domain.Events.Handlers
{
    public class OpportunitySkillEventHandler : INotificationHandler<OpportunitySkillAddedEvent>,
                                                INotificationHandler<OpportunitySkillUpdateEvent>,
                                                INotificationHandler<OpportunitySkillRemoveEvent>
    {
        private readonly ILogger<OpportunitySkillEventHandler> _logger;

        public OpportunitySkillEventHandler(ILogger<OpportunitySkillEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(OpportunitySkillAddedEvent Event, CancellationToken CancellationToken)
        {
            _logger.LogInformation($"A new Skill {Event.OpportunitySkill.Name} was added to the Opportunity {Event.OpportunityTitle}");
            return Task.CompletedTask;
        }
        public Task Handle(OpportunitySkillUpdateEvent Event, CancellationToken CancellationToken)
        {
            _logger.LogInformation($"The Skill {Event.OpportunitySkill.Name} who belongs to the Opportunity {Event.OpportunityTitle} was updated.");
            return Task.CompletedTask;
        }
        public Task Handle(OpportunitySkillRemoveEvent Event, CancellationToken CancellationToken)
        {
            _logger.LogInformation($"The Skill {Event.OpportunitySkill.Name} who belongs to the Opportunity {Event.OpportunityTitle} was removed.");
            return Task.CompletedTask;
        }
    }
}

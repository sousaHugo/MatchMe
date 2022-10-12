using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Opportunities.Domain.Events.Handlers;
using MatchMe.Opportunities.Domain.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MatchMe.Opportunities.Integration.Publishers;

namespace MatchMe.Opportunities.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection ServiceCollection)
        {
            ServiceCollection.AddCommands();
            
            ServiceCollection.AddTransient<INotificationHandler<OpportunityCreateEvent>, OpportunityEventHandler>();
            ServiceCollection.AddTransient<INotificationHandler<OpportunitySkillAddedEvent>, OpportunitySkillEventHandler>();
            ServiceCollection.AddTransient<INotificationHandler<OpportunitySkillRemoveEvent>, OpportunitySkillEventHandler>();
            ServiceCollection.AddTransient<INotificationHandler<OpportunitySkillUpdateEvent>, OpportunitySkillEventHandler>();
            ServiceCollection.AddTransient<INotificationHandler<OpportunityUpdateEvent>, OpportunityEventHandler>();

            ServiceCollection.AddTransient<IOpportunityCreatedPublisher, OpportunityCreatedPublisher>();

            return ServiceCollection;
        }
    }
}

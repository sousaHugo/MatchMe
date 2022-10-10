using MatchMe.Common.Shared.Commands;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Opportunities.Domain.Events.Handlers;
using MatchMe.Opportunities.Domain.Events;
using MatchMe.Opportunities.Domain.Factories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MatchMe.Opportunities.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection ServiceCollection)
        {
            ServiceCollection.AddCommands();
            ServiceCollection.AddSingleton<IOpportunityFactory, OpportunityFactory>();
            
            ServiceCollection.AddTransient<INotificationHandler<OpportunityCreateEvent>, OpportunityEventHandler>();
            ServiceCollection.AddTransient<INotificationHandler<OpportunitySkillAddedEvent>, OpportunitySkillEventHandler>();
            ServiceCollection.AddTransient<INotificationHandler<OpportunitySkillRemoveEvent>, OpportunitySkillEventHandler>();
            ServiceCollection.AddTransient<INotificationHandler<OpportunitySkillUpdateEvent>, OpportunitySkillEventHandler>();
            ServiceCollection.AddTransient<INotificationHandler<OpportunityUpdateEvent>, OpportunityEventHandler>();


            return ServiceCollection;
        }
    }
}

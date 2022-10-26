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
            ServiceCollection.AddTransient<INotificationHandler<OpportunityDomainEvent>, OpportunityEventHandler>();

            return ServiceCollection;
        }
    }
}

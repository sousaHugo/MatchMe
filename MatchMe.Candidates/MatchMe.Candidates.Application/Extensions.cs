using Mapster;
using MatchMe.Candidates.Domain.Events;
using MatchMe.Candidates.Domain.Events.Handlers;
using MatchMe.Common.Shared.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MatchMe.Candidates.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection ServiceCollection)
        {
            ServiceCollection.AddCommands();
            ServiceCollection.AddTransient<INotificationHandler<CandidateDomainEvent>, CandidateEventHandler>();

            return ServiceCollection;
        }
    }
}

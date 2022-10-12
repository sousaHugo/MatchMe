using Mapster;
using MatchMe.Candidates.Domain.Events;
using MatchMe.Candidates.Domain.Events.Handlers;
using MatchMe.Candidates.Domain.Factories;
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
            ServiceCollection.AddSingleton<ICandidateFactory, CandidateFactory>();

            ServiceCollection.AddTransient<INotificationHandler<CandidateDomainEvent>, CandidateEventHandler>();

            return ServiceCollection;
        }
    }
}

using Mapster;
using MatchMe.Candidates.Domain.Factories;
using MatchMe.Common.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MatchMe.Candidates.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection ServiceCollection)
        {
            ServiceCollection.AddCommands();
            ServiceCollection.AddSingleton<ICandidateFactory, CandidateFactory>();

            return ServiceCollection;
        }
    }
}

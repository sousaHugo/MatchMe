using MatchMe.Common.Shared.Extensions;
using MatchMe.Opportunities.Domain.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace MatchMe.Opportunities.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection ServiceCollection)
        {
            ServiceCollection.AddCommands();
            ServiceCollection.AddSingleton<IOpportunityFactory, OpportunityFactory>();


            return ServiceCollection;
        }
    }
}

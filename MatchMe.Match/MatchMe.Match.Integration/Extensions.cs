using MatchMe.Common.Shared.Integration;
using MatchMe.Match.Integration.Consumers.Candidates;
using MatchMe.Match.Integration.Consumers.Opportunities;
using Microsoft.Extensions.DependencyInjection;


namespace MatchMe.Match.Integration
{
    public static class Extensions
    {
        public static IServiceCollection AddIntegration(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitMQConsumer, RabbitMQConsumer>();
            services.AddHostedService<CandidateCreatedConsumer>();
            services.AddHostedService<OpportunityCreatedConsumer>();
            return services;
        }
    }
}

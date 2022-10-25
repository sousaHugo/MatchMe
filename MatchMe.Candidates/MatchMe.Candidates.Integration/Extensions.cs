using MatchMe.Candidates.Integration.Publishers;
using MatchMe.Common.Shared.Integration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchMe.Candidates.Integration
{
    public static class Extensions
    {
        public static IServiceCollection AddIntegration(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMQSender, RabbitMQSender>();
            services.AddScoped<ICandidateCreatedPublisher, CandidateCreatedPublisher>();
            return services;
        }
    }
}

using MatchMe.Common.Shared.Integration;
using MatchMe.Opportunities.Integration.Publishers;
using Microsoft.Extensions.DependencyInjection;


namespace MatchMe.Opportunities.Integration
{
    public static class Extensions
    {
        public static IServiceCollection AddIntegration(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMQSender, RabbitMQSender>();
            services.AddScoped<IOpportunityCreatedPublisher, OpportunityCreatedPublisher>();
            return services;
        }
    }
}

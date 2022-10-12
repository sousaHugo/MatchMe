using MatchMe.Common.Shared.Integration.Opportunities;
using MatchMe.Common.Shared.MassTransitRabbitMq;
using MatchMe.Common.Shared.MongoDb;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MatchMe.Match.Integration
{
    public static class Extensions
    {
        public static IServiceCollection AddIntegration(this IServiceCollection services)
        {
            services.AddMassTransitWithRabbitMq(Assembly.GetAssembly(typeof(Extensions)));

            return services;
        }
    }
}

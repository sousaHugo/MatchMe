using MatchMe.Common.Shared.MassTransitRabbitMq;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MatchMe.Match.Integration
{
    public static class Extensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransitWithRabbitMq(Assembly.GetAssembly(typeof(Extensions)));
        
            return services;
        }
        
    }
}

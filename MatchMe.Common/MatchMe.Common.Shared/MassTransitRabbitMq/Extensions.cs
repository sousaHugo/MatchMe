using System.Reflection;
using MassTransit;
using MatchMe.Common.Shared.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchMe.Common.Shared.MassTransitRabbitMq
{
    public static class Extensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services, Assembly Assembly = null)
        {
            services.AddMassTransit(x => {
                x.AddConsumers(Assembly.GetEntryAssembly());
                if (Assembly != null)
                    x.AddConsumers(Assembly);

                x.UsingRabbitMq((context, configurator) => {
                    var configuration = context.GetService<IConfiguration>();
                    var rabbitMqSettings = configuration.GetSection(nameof(RabbitMQOptions)).Get<RabbitMQOptions>();
                    var serviceSettings = configuration.GetSection(nameof(ServiceOptions)).Get<ServiceOptions>();

                    

                    configurator.Host(rabbitMqSettings.Host);
                    configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
                    configurator.UseMessageRetry(retryConfigurator => {
                        retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
                    });
                });

              
            });
           
            services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    options.WaitUntilStarted = true;
                    options.StartTimeout = TimeSpan.FromSeconds(10);
                    options.StopTimeout = TimeSpan.FromSeconds(30);
                });

            return services;
        }
    }
}

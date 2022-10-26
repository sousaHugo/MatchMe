using MatchMe.Common.Shared.Integration;
using MatchMe.Common.Shared.MongoDb;
using MatchMe.Match.Integration.Consumers.Candidates;
using MatchMe.Match.Integration.Consumers.Opportunities;
using MatchMe.Match.Integration.Messages;
using Microsoft.Extensions.DependencyInjection;


namespace MatchMe.Match.Integration
{
    public static class Extensions
    {
        public static IServiceCollection AddIntegration(this IServiceCollection services)
        {
            services.AddMongo()
                .AddMongoRepository<OpportunityCreatedMessageDto>("Opportunities")
                .AddMongoRepository<CandidateCreatedMessageDto>("Candidates");

            services.AddSingleton<IRabbitMQConsumer, RabbitMQConsumer>();
            services.AddHostedService<CandidateCreatedConsumer>();
            services.AddHostedService<OpportunityCreatedConsumer>();
            return services;
        }
    }
}

using MatchMe.Common.Shared.Extensions;
using MatchMe.Opportunities.Infrastructure.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchMe.Opportunities.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection ServiceCollection, IConfiguration Configuration)
        {
            ServiceCollection.AddWriteReadDbContext(Configuration);
            ServiceCollection.AddQueries();
            return ServiceCollection;
        }
    }
}

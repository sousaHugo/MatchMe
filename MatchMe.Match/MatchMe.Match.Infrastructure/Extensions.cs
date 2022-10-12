using MatchMe.Match.Infrastructure.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace MatchMe.Match.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection ServiceCollection, IConfiguration Configuration)
        {
            ServiceCollection.AddWriteReadDbContext(Configuration);

            return ServiceCollection;
        }
    }
}

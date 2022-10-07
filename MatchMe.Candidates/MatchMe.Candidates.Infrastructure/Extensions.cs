using MatchMe.Candidates.Infrastructure.EF;
using MatchMe.Common.Shared.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchMe.Candidates.Infrastructure
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

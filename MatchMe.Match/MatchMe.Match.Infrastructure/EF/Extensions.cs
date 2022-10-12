using MatchMe.Common.Shared.Extensions;
using MatchMe.Common.Shared.Options;
using MatchMe.Match.Domain.Repositories;
using MatchMe.Match.Infrastructure.EF.Contexts;
using MatchMe.Match.Infrastructure.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchMe.Match.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddWriteReadDbContext(this IServiceCollection ServiceCollection, IConfiguration Configuration)
        {
            ServiceCollection.AddScoped<IMatchRepository, MatchRepository>();
            var dbOptions = Configuration.GetOptions<ConnectionStringsOptions>("ConnectionStrings");

            ServiceCollection.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(dbOptions.DefaultConnection));
            ServiceCollection.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(dbOptions.DefaultConnection));

            return ServiceCollection;
        }
    }
}

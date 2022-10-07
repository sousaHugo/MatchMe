using MatchMe.Common.Shared.Extensions;
using MatchMe.Common.Shared.Options;
using MatchMe.Opportunities.Application.Services;
using MatchMe.Opportunities.Domain.Repositories;
using MatchMe.Opportunities.Infrastructure.EF.Contexts;
using MatchMe.Opportunities.Infrastructure.EF.Repositories;
using MatchMe.Opportunities.Infrastructure.EF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchMe.Opportunities.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddWriteReadDbContext(this IServiceCollection ServiceCollection, IConfiguration Configuration)
        {
            ServiceCollection.AddScoped<IOpportunityRepository, OpportunityRepository>();
            ServiceCollection.AddScoped<IOpportunityReadService, OpportunityReadService>();

            var dbOptions = Configuration.GetOptions<ConnectionStringsOptions>("ConnectionStrings");

            ServiceCollection.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(dbOptions.DefaultConnection));
            ServiceCollection.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(dbOptions.DefaultConnection));

            return ServiceCollection;
        }
    }
}

using MatchMe.Candidates.Application.Services;
using MatchMe.Candidates.Domain.Repositories;
using MatchMe.Candidates.Infrastructure.EF.Contexts;
using MatchMe.Candidates.Infrastructure.EF.Options;
using MatchMe.Candidates.Infrastructure.EF.Repositories;
using MatchMe.Candidates.Infrastructure.EF.Services;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Common.Shared.MongoDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MatchMe.Candidates.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddWriteReadDbContext(this IServiceCollection ServiceCollection, IConfiguration Configuration)
        {
            ServiceCollection.AddScoped<ICandidateRepository, CandidateRepository>();
            ServiceCollection.AddScoped<ICandidateReadService, CandidateReadService>();
            ServiceCollection.AddScoped<ICandidateSkillReadService, CandidateSkillReadService>();
            var dbOptions = Configuration.GetOptions<ConnectionStringsOptions>("ConnectionStrings");

            ServiceCollection.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(dbOptions.DefaultConnection));
            ServiceCollection.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(dbOptions.DefaultConnection));
            ServiceCollection.AddMongo().AddMongoRepository<DomainEvent>("Events");

            return ServiceCollection;
        }
    }  
}

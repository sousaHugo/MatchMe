using MatchMe.Opportunities.Infrastructure.EF.Config;
using MatchMe.Opportunities.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Opportunities.Infrastructure.EF.Contexts
{
    internal class ReadDbContext : DbContext
    {
        public DbSet<OpportunityReadModel> Opportunity { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> Options) :base(Options) { }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.HasDefaultSchema("opportunities");
            var configuration = new ReadConfiguration();
            ModelBuilder.ApplyConfiguration<OpportunityReadModel>(configuration);
            ModelBuilder.ApplyConfiguration<OpportunitySkillReadModel>(configuration);


            base.OnModelCreating(ModelBuilder); 
        }
    }
}

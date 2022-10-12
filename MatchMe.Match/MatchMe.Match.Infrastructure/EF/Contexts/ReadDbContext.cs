using MatchMe.Match.Infrastructure.EF.Config;
using MatchMe.Match.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Match.Infrastructure.EF.Contexts
{
    public class ReadDbContext : DbContext
    {
        public DbSet<MatchReadModel> Match { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> Options) : base(Options) { }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.HasDefaultSchema("matches");
            var configuration = new ReadConfiguration();
            ModelBuilder.ApplyConfiguration(configuration);

            base.OnModelCreating(ModelBuilder);
        }
    }
}

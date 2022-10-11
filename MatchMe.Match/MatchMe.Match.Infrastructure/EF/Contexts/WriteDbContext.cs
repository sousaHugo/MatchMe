using MatchMe.Match.Infrastructure.EF.Config;
using MatchMe.Match.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Match.Infrastructure.EF.Contexts
{
    internal class WriteDbContext : DbContext
    {
        public DbSet<Domain.Entities.Match> Match { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> Options) : base(Options) { }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.HasDefaultSchema("matches");
            var configuration = new WriteConfiguration();
            ModelBuilder.ApplyConfiguration(configuration);

            base.OnModelCreating(ModelBuilder);
        }
    }
}

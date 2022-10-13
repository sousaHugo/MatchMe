using MatchMe.Candidates.Infrastructure.EF.Config;
using MatchMe.Candidates.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Candidates.Infrastructure.EF.Contexts
{
    public class ReadDbContext : DbContext
    {
        public DbSet<CandidateReadModel> Candidate { get; set; }
        public DbSet<CandidateSkillReadModel> CandidateSkill { get; set; }
        public ReadDbContext(DbContextOptions<ReadDbContext> Options) : base(Options) { }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.HasDefaultSchema("candidates");
            var configuration = new ReadConfiguration();
            ModelBuilder.ApplyConfiguration<CandidateReadModel>(configuration);
            ModelBuilder.ApplyConfiguration<CandidateSkillReadModel>(configuration);
            ModelBuilder.ApplyConfiguration<CandidateExperienceReadModel>(configuration);
            ModelBuilder.ApplyConfiguration<CandidateEducationReadModel>(configuration);

            base.OnModelCreating(ModelBuilder);
        }
    }
}

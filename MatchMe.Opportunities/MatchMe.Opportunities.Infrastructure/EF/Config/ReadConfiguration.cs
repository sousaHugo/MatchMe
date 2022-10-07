using MatchMe.Opportunities.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchMe.Opportunities.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<OpportunityReadModel>,
        IEntityTypeConfiguration<OpportunitySkillReadModel>
    {
        public void Configure(EntityTypeBuilder<OpportunityReadModel> builder)
        {
            builder.ToTable("Opportunity");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Skills).WithOne(o => o.Opportunity);
        }

        public void Configure(EntityTypeBuilder<OpportunitySkillReadModel> builder)
        {
            builder.ToTable("OpportunitySkill");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.Mandatory);
            builder.Property(x => x.Min_Experience);
            builder.Property(x => x.Max_Experience);
        }
    }
}

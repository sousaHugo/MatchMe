using MatchMe.Opportunities.Domain.Entities;
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
            builder.ToTable(nameof(Opportunity));
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Skills).WithOne(o => o.Opportunity);
        }

        public void Configure(EntityTypeBuilder<OpportunitySkillReadModel> builder)
        {
            builder.ToTable(nameof(OpportunitySkill));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Mandatory);
            builder.Property(x => x.MinExperience);
            builder.Property(x => x.MaxExperience);
        }
    }
}

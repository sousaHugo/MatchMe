using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatchMe.Opportunities.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Opportunity>, IEntityTypeConfiguration<OpportunitySkill>
    {
        public void Configure(EntityTypeBuilder<Opportunity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(pr => pr.Id).HasConversion(id => id.Value, id => new OpportunityId(id));
            builder.Property(typeof(OpportunityName), "_title")
                .HasConversion(new ValueConverter<OpportunityName, string>(a => a.Value, a => new OpportunityName(a)))
                .HasColumnName("Title");
            builder.Property(typeof(OpportunityDescription), "_description")
               .HasConversion(new ValueConverter<OpportunityDescription, string>(a => a.Value, a => new OpportunityDescription(a)))
               .HasColumnName("Description");

            builder.HasMany(typeof(OpportunitySkill), "_skills");
            builder.ToTable("Opportunity");
        }

        public void Configure(EntityTypeBuilder<OpportunitySkill> builder)
        {
            builder.ToTable("OpportunitySkill");
            builder.Property<Guid>("Id");
            builder.Property(a => a.Name);
            builder.Property(a => a.Experience);
            builder.Property(a => a.Mandatory);
        }
    }
}

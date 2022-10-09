using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpportunitySkill = MatchMe.Opportunities.Domain.Entities.OpportunitySkill;

namespace MatchMe.Opportunities.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Opportunity>, IEntityTypeConfiguration<OpportunitySkill>
    {
        public void Configure(EntityTypeBuilder<Opportunity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(pr => pr.Id).HasConversion(id => id.Value, id => new Identity(id));
            
            builder.Property(a => a.Title)
                .IsRequired();

            builder.Property(a => a.Descritption)
               .IsRequired();

            builder.Property(a => a.Reference)
               .IsRequired();

            builder.Property(a => a.ClientId)
               .IsRequired();

            builder.Property(a => a.Responsible)
               .IsRequired();

            builder.Property(a => a.Location)
               .IsRequired();

            builder.Property(a => a.Status)
                .HasConversion(new ValueConverter<OpportunityStatusObject, string>(a => a.Value.ToString(), a => new OpportunityStatusObject(Enum.Parse<OpportunityStatusEnum>(a))))
                .IsRequired();

            builder.Property(a => a.BeginDate)
               .IsRequired();

            builder.Property(a => a.EndDate)
               .IsRequired();

            builder.Property(a => a.MinSalaryYear);

            builder.Property(a => a.MaxSalaryYear);

            builder.Property(a => a.MinExperienceMonth);

            builder.Property(a => a.MaxExperienceMonth);

            builder.HasMany(a => a.Skills).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(nameof(Opportunity));
        }

        public void Configure(EntityTypeBuilder<OpportunitySkill> builder)
        {
            builder.ToTable(nameof(OpportunitySkill));
            builder.Property(pr => pr.Id).HasConversion(id => id.Value, id => new Identity(id));

            builder.Property(a => a.Name)
               .IsRequired();

            builder.Property(a => a.MinExperience)
               .IsRequired();

            builder.Property(a => a.MaxExperience)
              .IsRequired();

            builder.Property(a => a.Level)
              .HasConversion(new ValueConverter<SkillLevelObject, string>(a => a.Value.ToString(), a => new SkillLevelObject(Enum.Parse<SkillLevelEnum>(a))))
              .IsRequired();

            builder.Property(a => a.Mandatory)
               .IsRequired();
        }
    }
}

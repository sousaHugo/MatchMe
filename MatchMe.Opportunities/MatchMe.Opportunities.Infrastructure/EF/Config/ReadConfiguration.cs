using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatchMe.Opportunities.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<OpportunityReadModel>,
        IEntityTypeConfiguration<OpportunitySkillReadModel>
    {
        public void Configure(EntityTypeBuilder<OpportunityReadModel> builder)
        {
            builder.ToTable(nameof(Opportunity));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.ClientId);
            builder.Property(x => x.Responsible);
            builder.Property(x => x.Reference);
            builder.Property(x => x.MinSalaryYear);
            builder.Property(x => x.MaxSalaryYear);
            builder.Property(x => x.MinExperienceMonth);
            builder.Property(x => x.MaxExperienceMonth);
            builder.Property(x => x.BeginDate);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.Location);
            builder.Property(a => a.Status)
            .HasConversion(new ValueConverter<OpportunityStatusEnum, string>(a => a.ToString(), a => Enum.Parse<OpportunityStatusEnum>(a)));
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
            builder.Property(x => x.OpportunityId);
            builder.Property(a => a.Level)
            .HasConversion(new ValueConverter<SkillLevelEnum, string>(a => a.ToString(), a => Enum.Parse<SkillLevelEnum>(a)));
        }
    }
}

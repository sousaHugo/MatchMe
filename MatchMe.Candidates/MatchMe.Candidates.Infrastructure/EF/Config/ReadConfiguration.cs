using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MatchMe.Candidates.Infrastructure.EF.Models;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Candidates.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<CandidateReadModel>,
         IEntityTypeConfiguration<CandidateSkillReadModel>
    {
        public void Configure(EntityTypeBuilder<CandidateReadModel> builder)
        {
            builder.ToTable(nameof(Candidate));
            builder.HasKey(x => x.Id);
            builder.Property(a => a.MaritalStatus)
              .HasConversion(new ValueConverter<MaritalStatusEnum, string>(a => a.ToString(), a => Enum.Parse<MaritalStatusEnum>(a)));
            builder.Property(a => a.Gender)
              .HasConversion(new ValueConverter<GenderEnum, string>(a => a.ToString(), a => Enum.Parse<GenderEnum>(a)));
            builder.HasMany(x => x.Skills).WithOne(o => o.Candidate);
        }

        public void Configure(EntityTypeBuilder<CandidateSkillReadModel> builder)
        {
            builder.ToTable(nameof(CandidateSkill));
            builder.Property(a => a.Name);
            builder.Property(a => a.Experience);
            builder.Property(a => a.Level)
                .HasConversion(new ValueConverter<SkillLevelEnum, string>(a => a.ToString(), a => Enum.Parse<SkillLevelEnum>(a)));
        }
    }
}

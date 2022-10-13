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
         IEntityTypeConfiguration<CandidateSkillReadModel>,
          IEntityTypeConfiguration<CandidateExperienceReadModel>,
          IEntityTypeConfiguration<CandidateEducationReadModel>
    {
        public void Configure(EntityTypeBuilder<CandidateReadModel> builder)
        {
            builder.ToTable(nameof(Candidate));
            builder.HasKey(x => x.Id);
            builder.Property(a => a.FirstName);
            builder.Property(a => a.LastName);
            builder.Property(a => a.FiscalNumber);
            builder.Property(a => a.CitizenCardNumber);
            builder.Property(a => a.Email);
            builder.Property(a => a.DateOfBirth);
            builder.Property(a => a.MobilePhone);
            builder.Property(a => a.Nationality);
            builder.Property(a => a.MaritalStatus)
              .HasConversion(new ValueConverter<MaritalStatusEnum, string>(a => a.ToString(), a => Enum.Parse<MaritalStatusEnum>(a)));
            builder.Property(a => a.Gender)
              .HasConversion(new ValueConverter<GenderEnum, string>(a => a.ToString(), a => Enum.Parse<GenderEnum>(a)));
            builder.HasMany(x => x.Skills).WithOne(o => o.Candidate);
            builder.HasMany(x => x.Experiencies).WithOne(o => o.Candidate);
            builder.HasMany(x => x.Educations).WithOne(o => o.Candidate);

            builder.OwnsOne(x => x.Address, y =>
            {
                y.Property(y => y.Street).HasColumnName("Street").IsRequired();
                y.Property(y => y.State).HasColumnName("State").IsRequired();
                y.Property(y => y.PostCode).HasColumnName("PostCode").IsRequired();
                y.Property(y => y.City).HasColumnName("City").IsRequired();
                y.Property(y => y.Country).HasColumnName("Country").IsRequired();
            });
        }

        public void Configure(EntityTypeBuilder<CandidateSkillReadModel> builder)
        {
            builder.ToTable(nameof(CandidateSkill));
            builder.Property(a => a.Name);
            builder.Property(a => a.Experience);
            builder.Property(a => a.Level)
                .HasConversion(new ValueConverter<SkillLevelEnum, string>(a => a.ToString(), a => Enum.Parse<SkillLevelEnum>(a)));
        }

        public void Configure(EntityTypeBuilder<CandidateExperienceReadModel> builder)
        {
            builder.ToTable(nameof(CandidateExperience));
            builder.Property(a => a.Role);
            builder.Property(a => a.Company);
            builder.Property(a => a.City);
            builder.Property(a => a.Country);
            builder.Property(a => a.BeginDate);
            builder.Property(a => a.EndDate);
            builder.Property(a => a.Description);
            builder.Property(a => a.Responsibilities);
        }

        public void Configure(EntityTypeBuilder<CandidateEducationReadModel> builder)
        {
            builder.ToTable(nameof(CandidateEducation));
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Organization).IsRequired();
            builder.OwnsOne(x => x.Address, y =>
            {
                y.Property(y => y.Street).HasColumnName("Street").IsRequired();
                y.Property(y => y.State).HasColumnName("State").IsRequired();
                y.Property(y => y.PostCode).HasColumnName("PostCode").IsRequired();
                y.Property(y => y.City).HasColumnName("City").IsRequired();
                y.Property(y => y.Country).HasColumnName("Country").IsRequired();
            });
            builder.Property(a => a.BeginDate).IsRequired();
            builder.Property(a => a.EndDate);
            builder.Property(a => a.Description);
        }
    }
}

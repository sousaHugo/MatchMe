using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain.ValueObjects;
using IdGen;
using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Candidates.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Candidate>, IEntityTypeConfiguration<CandidateSkill>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(pr => pr.Id).HasConversion(id => id.Value, id => new Identity(id));

            builder.Property(a => a.FirstName)
                .IsRequired();

            builder.Property(a => a.LastName)
               .IsRequired();

            builder.Property(a => a.FiscalNumber)
              .HasConversion(new ValueConverter<FiscalNumberObject, string>(a => a.Value, a => new FiscalNumberObject(a)));

            builder.Property(a => a.CitizenCardNumber)
              .HasConversion(new ValueConverter<CitizenCardNumberObject, string>(a => a.Value, a => new CitizenCardNumberObject(a)));

            builder.Property(a => a.DateOfBirth)
               .HasConversion(new ValueConverter<DateOfBirthObject, DateTime>(a => a.Value, a => new DateOfBirthObject(a)));

            //builder.Property(a => a.Address)
            //   .HasConversion(new ValueConverter<AddressObject, string>(l => l.ToString(), l => AddressObject.Create(l)));

            builder.OwnsOne(x => x.Address, y =>
            {
                y.Property(y => y.Street).HasColumnName("Street").IsRequired();
                y.Property(y => y.State).HasColumnName("State").IsRequired();
                y.Property(y => y.PostCode).HasColumnName("PostCode").IsRequired();
                y.Property(y => y.City).HasColumnName("City").IsRequired();
                y.Property(y => y.Country).HasColumnName("Country").IsRequired();
            });

            builder.Property(a => a.Nationality).IsRequired();

            builder.Property(a => a.MobilePhone)
             .IsRequired();

            builder.Property(a => a.Email)
              .HasConversion(new ValueConverter<EmailObject, string>(a => a.Value, a => new EmailObject(a)));

            builder.Property(a => a.Gender)
             .HasConversion(new ValueConverter<GenderObject, string>(a => a.Value.ToString(), a => new GenderObject(Enum.Parse<GenderEnum>(a))));

            builder.Property(a => a.MaritalStatus)
            .HasConversion(new ValueConverter<MaritalStatusObject, string>(a => a.Value.ToString(), a => new MaritalStatusObject(Enum.Parse<MaritalStatusEnum>(a))));

            builder.HasMany(a => a.Skills).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(nameof(Candidate));
        }

        public void Configure(EntityTypeBuilder<CandidateSkill> builder)
        {
            builder.ToTable(nameof(CandidateSkill));
            builder.Property(pr => pr.Id).HasConversion(id => id.Value, id => new Identity(id));
            builder.Property(a => a.Name);
            builder.Property(a => a.Experience);

            builder.Property(typeof(SkillLevelObject), "_level")
               .HasConversion(new ValueConverter<SkillLevelObject, string>(a => a.Value.ToString(), a => new SkillLevelObject(Enum.Parse<SkillLevelEnum>(a))))
               .HasColumnName("Level");
        }
    }
}

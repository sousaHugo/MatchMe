using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Match.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatchMe.Match.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Domain.Entities.Match>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Match> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(pr => pr.Id).HasConversion(id => id.Value, id => new Identity(id));

            builder.Property(a => a.CandidateId)
                .IsRequired();

            builder.Property(a => a.CandidateName)
               .IsRequired();

            builder.Property(a => a.OpportunityId)
               .IsRequired();

            builder.Property(a => a.OpportunityTitle)
               .IsRequired();

            builder.Property(a => a.Automatic)
               .IsRequired();

            builder.Property(a => a.Percentage)
               .IsRequired();

            builder.Property(a => a.Status)
                .HasConversion(new ValueConverter<MatchStatusObject, string>(a => a.Value.ToString(), a => new MatchStatusObject(Enum.Parse<MatchStatusEnum>(a))))
                .IsRequired();

            builder.ToTable(nameof(Domain.Entities.Match));
        }
    }
}

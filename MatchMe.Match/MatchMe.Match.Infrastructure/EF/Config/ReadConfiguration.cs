using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Match.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatchMe.Match.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<MatchReadModel>
    {
        public void Configure(EntityTypeBuilder<MatchReadModel> builder)
        {
            builder.ToTable(nameof(Domain.Entities.Match));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CandidateId).IsRequired();
            builder.Property(x => x.CandidateName).IsRequired();
            builder.Property(x => x.OpportunityId).IsRequired();
            builder.Property(x => x.OpportunityTitle).IsRequired();
            builder.Property(x => x.Automatic);
            builder.Property(x => x.Percentage);
            builder.Property(a => a.Status).HasConversion(new ValueConverter<MatchStatusEnum, string>(a => a.ToString(), a => Enum.Parse<MatchStatusEnum>(a))).IsRequired();
        }
    }
}

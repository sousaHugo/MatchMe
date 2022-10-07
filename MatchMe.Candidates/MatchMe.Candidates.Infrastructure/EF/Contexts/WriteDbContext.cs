using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Infrastructure.EF.Config;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MatchMe.Candidates.Infrastructure.EF.Contexts
{
    public class WriteDbContext : DbContext
    {
        private readonly IPublisher _publisher;
        private readonly ILogger<WriteDbContext> _logger;


        public DbSet<Candidate> Candidate { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> Options, IPublisher Publisher, ILogger<WriteDbContext> Logger) : base(Options) { _publisher = Publisher; _logger = Logger; }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.HasDefaultSchema("candidates");

            var configuration = new WriteConfiguration();
            ModelBuilder.ApplyConfiguration<Candidate>(configuration);
            ModelBuilder.ApplyConfiguration<CandidateSkill>(configuration);

            base.OnModelCreating(ModelBuilder);

            ModelBuilder.Entity<Candidate>()
                .Ignore(x => x.Events);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            var events = ChangeTracker.Entries<AggregateRoot<Identity>>()
                    .Select(x => x.Entity.Events)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .ToArray();

            foreach (var @event in events)
            {
                @event.IsPublished = true;

                _logger.LogInformation("New domain event {Event}", @event.GetType().Name);

                await _publisher.Publish(@event, cancellationToken);
            }

            return result;
        }
    }
}

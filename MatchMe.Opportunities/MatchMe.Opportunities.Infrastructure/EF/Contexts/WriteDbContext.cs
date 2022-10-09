using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Domain;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.ValueObjects;
using MatchMe.Opportunities.Infrastructure.EF.Config;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpportunitySkill = MatchMe.Opportunities.Domain.Entities.OpportunitySkill;

namespace MatchMe.Opportunities.Infrastructure.EF.Contexts
{
    internal class WriteDbContext : DbContext
    {
        private readonly IPublisher _publisher;
        private readonly ILogger<WriteDbContext> _logger;

        public DbSet<Opportunity> Opportunity { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> Options, IPublisher Publisher, ILogger<WriteDbContext> Logger) : base(Options) { _publisher = Publisher; _logger = Logger; }
       
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.HasDefaultSchema("opportunities");
            
            var configuration = new WriteConfiguration();
            ModelBuilder.ApplyConfiguration<Opportunity>(configuration);
            ModelBuilder.ApplyConfiguration<OpportunitySkill>(configuration);
            
            base.OnModelCreating(ModelBuilder);

            ModelBuilder.Entity<Opportunity>()
             .Ignore(x => x.Events);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken CancellationToken = default)
        {
            var result = await base.SaveChangesAsync(CancellationToken);

            var events = ChangeTracker.Entries<AggregateRoot<Identity>>()
                    .Select(x => x.Entity.Events)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .ToArray();

            foreach (var @event in events)
            {
                @event.IsPublished = true;

                _logger.LogInformation("New domain event {Event}", @event.GetType().Name);

                await _publisher.Publish(@event, CancellationToken);
            }

            return result;
        }
    }
}
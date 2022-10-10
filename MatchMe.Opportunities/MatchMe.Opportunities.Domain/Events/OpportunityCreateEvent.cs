using MatchMe.Common.Shared.Domain;
using MatchMe.Opportunities.Domain.Entities;

namespace MatchMe.Opportunities.Domain.Events
{
    public class OpportunityCreateEvent : DomainEvent
    {
        private readonly Opportunity _opportunity;
        public OpportunityCreateEvent(Opportunity Opportunity)
        {
            _opportunity = Opportunity;
        }

        public Opportunity Opportunity => _opportunity;
    }
}

using MatchMe.Common.Shared.Domain;
using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Events.Models;
using MatchMe.Opportunities.Domain.Mapping;

namespace MatchMe.Opportunities.Domain.Events
{
    public class OpportunityDomainEvent : DomainEvent
    {
        public OpportunityDomainEvent(Opportunity Opportunity, string Type)
        {
            this.Type = Type;
            this.Opportunity = Opportunity.AsOpportunityDEModel();
        }
        public OpportunityDEModel Opportunity { get; protected set; }
        public string Type { get; protected set; }  
    }
}

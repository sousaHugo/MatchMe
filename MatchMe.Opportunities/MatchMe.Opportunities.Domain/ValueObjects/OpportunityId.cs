using MatchMe.Opportunities.Domain.Exceptions;

namespace MatchMe.Opportunities.Domain.ValueObjects
{
    public record OpportunityId
    {
        public Guid Value { get; }

        public OpportunityId(Guid Value)
        {
            if (Value == Guid.Empty)
                throw new EmptyOpportunityIdException();

            this.Value = Value;
        }

        public static implicit operator Guid(OpportunityId OpportunityName) => OpportunityName.Value;

        public static implicit operator OpportunityId(Guid Value) => new(Value);
    }
}

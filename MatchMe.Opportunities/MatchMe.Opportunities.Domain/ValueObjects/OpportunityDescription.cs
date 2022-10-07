using MatchMe.Opportunities.Domain.Exceptions;

namespace MatchMe.Opportunities.Domain.ValueObjects
{
    public record OpportunityDescription
    {
        public OpportunityDescription(string Value)
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new EmptyOpportunityDescriptionException();

            this.Value = Value;
        }

        public string Value { get; }

        public static implicit operator string(OpportunityDescription OpportunityDescription) => OpportunityDescription.Value;

        public static implicit operator OpportunityDescription(string Value) => new(Value);
    }
}

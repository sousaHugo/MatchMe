using MatchMe.Opportunities.Domain.Exceptions;

namespace MatchMe.Opportunities.Domain.ValueObjects
{
    public record OpportunityName
    {
        public OpportunityName(string Value)
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new EmptyOpportunityNameException();

            this.Value = Value;
        }

        public string Value { get; }

        public static implicit operator string (OpportunityName OpportunityName) => OpportunityName.Value;

        public static implicit operator OpportunityName (string Value) => new(Value);   
    }
}

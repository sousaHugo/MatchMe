namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record Identity
    {
        public long Value { get; }

        public Identity(long Value)
        {
            this.Value = Value;
        }

        public static implicit operator long(Identity OpportunityName) => OpportunityName.Value;

        public static implicit operator Identity(long Value) => new(Value);
    }
}

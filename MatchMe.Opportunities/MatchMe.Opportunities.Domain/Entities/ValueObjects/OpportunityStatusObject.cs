using FluentValidation;
using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Opportunities.Domain.Entities.ValueObjects
{
    public record OpportunityStatusObject
    {
        public OpportunityStatusObject(OpportunityStatusEnum Value)
        {
            this.Value = Value;
        }
        public OpportunityStatusEnum Value { get; }

        public static implicit operator OpportunityStatusEnum(OpportunityStatusObject TextObject) => TextObject.Value;

        public static implicit operator OpportunityStatusObject(OpportunityStatusEnum Value) => new(Value);
    }
    public class OpportunityStatusObjectValidator : Validator<OpportunityStatusObject>
    {
        public OpportunityStatusObjectValidator()
        {
            RuleFor(r => r.Value).NotNull().IsInEnum();
        }
    }
}

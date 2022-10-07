using FluentValidation;
using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record MaritalStatusObject
    {
        public MaritalStatusObject(MaritalStatusEnum Value) 
        {
            this.Value = Value;
        }
        public MaritalStatusEnum Value { get; }

        public static implicit operator MaritalStatusEnum(MaritalStatusObject TextObject) => TextObject.Value;

        public static implicit operator MaritalStatusObject(MaritalStatusEnum Value) => new(Value);
    }
    public class MaritalStatusObjectValidator : AbstractValidator<MaritalStatusObject>
    {
        public MaritalStatusObjectValidator()
        {
            RuleFor(r => r.Value)
                .NotNull()
                .IsInEnum()
                .WithName("Marital Status");
        }
    }
}

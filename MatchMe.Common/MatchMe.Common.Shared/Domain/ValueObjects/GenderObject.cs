using FluentValidation;
using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record GenderObject
    {
        public GenderObject(GenderEnum Value)
        {
            this.Value = Value;
        }
        public GenderEnum Value { get; }

        public static implicit operator GenderEnum(GenderObject TextObject) => TextObject.Value;

        public static implicit operator GenderObject(GenderEnum Value) => new(Value);
    }
    public class GenderObjectValidator : AbstractValidator<GenderObject>
    {
        public GenderObjectValidator()
        {
            RuleFor(r => r.Value)
                .NotNull()
                .IsInEnum()
                .WithName("Gender");
        }
    }
}

using FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record IntegerObject
    {
        public IntegerObject(int Value)
        {
            this.Value = Value;
        }
        public int Value { get; }

        public static implicit operator int(IntegerObject TextObject) => TextObject.Value;

        public static implicit operator IntegerObject(int Value) => new(Value);
    }
    public class IntegerObjectValidator : AbstractValidator<TextObject>
    {
        public IntegerObjectValidator()
        {
            RuleFor(r => r.Value).NotNull();
        }
    }
}

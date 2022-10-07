using FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record TextObject
    {
        public TextObject(string Value)
        {
            this.Value = Value;
        }
        public string Value { get; }

        public static implicit operator string(TextObject TextObject) => TextObject.Value;

        public static implicit operator TextObject(string Value) => new(Value);
    }
    public class TextObjectValidator : AbstractValidator<TextObject>
    {
        public TextObjectValidator()
        {
            RuleFor(r => r.Value).NotEmpty().NotNull();
        }
    }
}

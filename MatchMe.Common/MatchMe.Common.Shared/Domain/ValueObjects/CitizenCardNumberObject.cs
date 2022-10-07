using FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record CitizenCardNumberObject
    {
        public CitizenCardNumberObject(string Value)
        {
            this.Value = Value;
        }
        public string Value { get; }

        public static implicit operator string(CitizenCardNumberObject TextObject) => TextObject.Value;

        public static implicit operator CitizenCardNumberObject(string Value) => new(Value);
    }
    public class CitizenCardNumbertValidator : AbstractValidator<CitizenCardNumberObject>
    {
        public CitizenCardNumbertValidator()
        {
            RuleFor(r => r.Value).NotNull().NotEmpty();
        }
    }
}

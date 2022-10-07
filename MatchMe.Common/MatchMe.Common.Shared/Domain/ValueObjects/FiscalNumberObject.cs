using FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record FiscalNumberObject
    {
        public FiscalNumberObject(string Value)
        {
            this.Value = Value;
        }
        public string Value { get; }

        public static implicit operator string(FiscalNumberObject TextObject) => TextObject.Value;

        public static implicit operator FiscalNumberObject(string Value) => new(Value);
    }
    public class FiscalNumberObjectValidator : AbstractValidator<FiscalNumberObject>
    {
        public FiscalNumberObjectValidator()
        {
            RuleFor(r => r.Value).NotNull().NotEmpty();
            RuleFor(r => r.Value).Length(9);
            RuleFor(r => r.Value)
                .Custom((r, context) =>
                {
                    if ((!(int.TryParse(r, out int value))))
                    {
                        context.AddFailure($"{r} is not a valid for Fiscal Number.");
                    }
                });
        }
    }
}

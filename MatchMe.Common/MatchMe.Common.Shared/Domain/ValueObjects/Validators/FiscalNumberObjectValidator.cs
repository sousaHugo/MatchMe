using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects.Validators
{
    public class FiscalNumberObjectValidator : Validator<FiscalNumberObject>
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

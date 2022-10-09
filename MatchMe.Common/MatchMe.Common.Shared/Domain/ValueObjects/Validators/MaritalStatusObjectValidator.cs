using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects.Validators
{
    public class MaritalStatusObjectValidator : Validator<MaritalStatusObject>
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

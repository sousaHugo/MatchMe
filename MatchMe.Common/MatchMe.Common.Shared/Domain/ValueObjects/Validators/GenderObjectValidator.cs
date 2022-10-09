using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects.Validators
{
    public class GenderObjectValidator : Validator<GenderObject>
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

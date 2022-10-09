using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects.Validators
{
    public class DateOfBirthObjectValidator : Validator<DateOfBirthObject>
    {
        public DateOfBirthObjectValidator()
        {
            RuleFor(r => r.Value).LessThan(DateTime.Today);
        }
    }
}

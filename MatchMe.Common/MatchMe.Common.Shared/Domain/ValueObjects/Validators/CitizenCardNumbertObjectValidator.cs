using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects.Validators
{
    public class CitizenCardNumbertObjectValidator : Validator<CitizenCardNumberObject>
    {
        public CitizenCardNumbertObjectValidator()
        {
            //Specify specific rule
            RuleFor(r => r.Value).NotNullOrEmpty();
        }
    }
}

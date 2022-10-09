
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects.Validators
{
    public class AddressObjectValidator : Validator<AddressObject>
    {
        public AddressObjectValidator()
        {
            RuleFor(r => r.Street).NotNullOrEmpty();
            RuleFor(r => r.City).NotNullOrEmpty();
            RuleFor(r => r.State).NotNullOrEmpty();
            RuleFor(r => r.PostCode).NotNullOrEmpty();
            RuleFor(r => r.Country).NotNullOrEmpty();
        }
    }
}

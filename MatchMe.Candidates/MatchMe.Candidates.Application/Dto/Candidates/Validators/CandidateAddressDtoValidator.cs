using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Candidates.Application.Dto.Candidates.Validators
{
    public class CandidateAddressDtoValidator : AbstractValidator<CandidateAddressDto>
    {
        public CandidateAddressDtoValidator()
        {
            RuleFor(x => x.Street).NotNullOrEmpty().WithName("Street");
            RuleFor(x => x.City).NotNullOrEmpty().WithName("City");
            RuleFor(x => x.State).NotNullOrEmpty().WithName("State");
            RuleFor(x => x.PostCode).NotNullOrEmpty().WithName("Postal Code");
            RuleFor(x => x.Country).NotNullOrEmpty().WithName("Country");
        }

    }
}

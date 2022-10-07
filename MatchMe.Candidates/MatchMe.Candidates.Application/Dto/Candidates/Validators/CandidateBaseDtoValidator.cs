using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Candidates.Application.Dto.Candidates.Validators
{
    public class CandidateBaseDtoValidator : AbstractValidator<CandidateBaseDto>
    {
        public CandidateBaseDtoValidator()
        {
            RuleFor(x => x.FirstName)
                 .NotNullOrEmpty().WithName("First Name");

            RuleFor(x => x.LastName)
                .NotNullOrEmpty().WithName("Last Name");

            RuleFor(x => x.FiscalNumber)
                .NotNullOrEmpty()
                .Length(9).WithName("Fiscal Number");

            RuleFor(x => x.CitizenCardNumber).NotNullOrEmpty().WithName("Citizen Card Number");
            RuleFor(x => x.DateOfBirth).NotNullOrEmpty()
                .LessThan(DateTime.Today).WithName("Date of Birth");

            RuleFor(x => x.Nationality).NotNullOrEmpty().WithName("Nationality");
            RuleFor(x => x.MobilePhone).NotNullOrEmpty().WithName("Mobile Phone");
            RuleFor(x => x.Email).NotNullOrEmpty().WithName("Email");
            RuleFor(x => x.Gender).NotNull().IsInEnum().WithName("Gender");
            RuleFor(x => x.MaritalStatus).NotNull().IsInEnum().WithName("Marital Status");
            RuleFor(x => x.Address).NotNullOrEmpty().SetValidator(new CandidateAddressDtoValidator()).WithName("Address");
        }

    }
}

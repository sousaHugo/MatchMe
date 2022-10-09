using FluentValidation;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Domain.ValueObjects.Validators;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Candidates.Domain.Entities.Validators
{
    public class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(r => r.FirstName).NotNullOrEmpty();
            RuleFor(r => r.LastName).NotNullOrEmpty();
            RuleFor(r => r.DateOfBirth).NotNull().SetValidator(new DateOfBirthObjectValidator());
            RuleFor(r => r.Address).NotNull().SetValidator(new AddressObjectValidator());
            RuleFor(r => r.Gender).NotNull().SetValidator(new GenderObjectValidator());
            RuleFor(r => r.Email).NotNullOrEmpty().SetValidator(new EmailObjectValidator());

            When(r => r.MaritalStatus is not null, () => {
                RuleFor(r => r.MaritalStatus).SetValidator(new MaritalStatusObjectValidator());
            });

            RuleFor(r => r.Skills).Must(skills => skills.DistinctBy(a => a.Name).Count() == skills.Count)
                .WithMessage("One or more Skills are duplicated.");

        }
    }
}

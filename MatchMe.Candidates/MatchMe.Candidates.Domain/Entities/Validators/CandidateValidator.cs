using FluentValidation;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Entities.Validators
{
    public class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(r => r.FirstName).NotNull().SetValidator(new TextObjectValidator());
            RuleFor(r => r.LastName).NotNull().SetValidator(new TextObjectValidator());
            RuleFor(r => r.DateOfBirth).NotNull().SetValidator(new DateOfBirthObjectValidator());
            RuleFor(r => r.Address).NotNull().SetValidator(new AddressObjectValidator());
            RuleFor(r => r.Gender).NotNull().SetValidator(new GenderObjectValidator());
            RuleFor(r => r.Email).NotNull().SetValidator(new EmailObjectValidator());

            When(r => r.Nationality is not null, () => {
                RuleFor(r => r.Nationality).SetValidator(new TextObjectValidator());
            });

            When(r => r.MobilePhone is not null, () => {
                RuleFor(r => r.MobilePhone).SetValidator(new TextObjectValidator());
            });

            When(r => r.MaritalStatus is not null, () => {
                RuleFor(r => r.MaritalStatus).SetValidator(new MaritalStatusObjectValidator());
            });

            RuleFor(r => r.Skills).Must(skills => skills.DistinctBy(a => a.Name).Count() == skills.Count)
                .WithMessage("One or more Skills are duplicated.");

        }
    }
}

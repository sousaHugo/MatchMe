using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;
using MatchMe.Match.Domain.Entities.ValueObjects;

namespace MatchMe.Match.Domain.Entities.Validators
{
    public class MatchValidator : Validator<Match>
    {
        public MatchValidator()
        {
            RuleFor(r => r.CandidateId).NotNull();
            RuleFor(r => r.CandidateName).NotNullOrEmpty();
            RuleFor(r => r.OpportunityId).NotNull();
            RuleFor(r => r.OpportunityTitle).NotNullOrEmpty();
            RuleFor(r => r.Automatic).NotNull();
            RuleFor(r => r.Percentage).NotNull().InclusiveBetween(0,100);
            RuleFor(r => r.Status).NotNull().SetValidator(new MatchStatusObjectValidator());
        }
    }
}

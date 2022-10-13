using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;


namespace MatchMe.Candidates.Domain.Entities.Validators
{
    internal class CandidateEducationValidator : Validator<CandidateEducation>
    {
        public CandidateEducationValidator()
        {
            RuleFor(r => r.Address).NotNull();
            RuleFor(r => r.Title).NotNullOrEmpty();
            RuleFor(r => r.BeginDate).NotNull();
            RuleFor(r => r.Organization).NotNullOrEmpty();
            RuleFor(r => r.Description).NotNullOrEmpty();
        }
    }
}

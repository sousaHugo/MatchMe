using MatchMe.Common.Shared.FluentValidation;


namespace MatchMe.Candidates.Domain.Entities.Validators
{
    internal class CandidateExperienceValidator : Validator<CandidateExperience>
    {
        public CandidateExperienceValidator()
        {
            RuleFor(r => r.Responsibilities).NotNullOrEmpty();
            RuleFor(r => r.Role).NotNullOrEmpty();
            RuleFor(r => r.Company).NotNullOrEmpty();
            RuleFor(r => r.Country).NotNullOrEmpty();
            RuleFor(r => r.Description).NotNullOrEmpty();
        }
    }
}

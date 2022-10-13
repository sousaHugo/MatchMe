using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;


namespace MatchMe.Candidates.Domain.Entities.Validators
{
    internal class CandidateSkillValidator : Validator<CandidateSkill>
    {
        public CandidateSkillValidator()
        {
            RuleFor(r => r.Experience).NotNull();
            RuleFor(r => r.Level).NotNull();
            RuleFor(r => r.Name).NotNullOrEmpty();
        }
    }
}

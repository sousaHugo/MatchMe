using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Candidates.Application.Dto.CandidatesSkill.Validators
{
    public class CandidateSkillBaseDtoValidator : Validator<CandidateSkillBaseDto>
    {
        public CandidateSkillBaseDtoValidator()
            : base()
        {
            RuleFor(x => x.Name)
                .NotNullOrEmpty().WithName("Skill");

            RuleFor(x => x.Experience)
                .NotNull().GreaterThan(0).WithName("Skill Experience");

            RuleFor(x => x.Level)
                .NotNull()
                .IsInEnum()
                .WithName("Skill Level");
        }
    }
}

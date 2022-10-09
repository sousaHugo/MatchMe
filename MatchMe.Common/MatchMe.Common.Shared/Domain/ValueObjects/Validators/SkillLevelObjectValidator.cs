using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Common.Shared.Domain.ValueObjects.Validators
{
    public class SkillLevelObjectValidator : Validator<SkillLevelObject>
    {
        public SkillLevelObjectValidator()
        {
            RuleFor(r => r.Value)
                .NotNull()
                .IsInEnum()
                .WithName("Skill Level");
        }
    }
}

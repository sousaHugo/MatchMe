using FluentValidation;
using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record SkillLevelObject
    {
        public SkillLevelObject(SkillLevelEnum Value)
        {
            this.Value = Value;
        }
        public SkillLevelEnum Value { get; }

        public static implicit operator SkillLevelEnum(SkillLevelObject TextObject) => TextObject.Value;

        public static implicit operator SkillLevelObject(SkillLevelEnum Value) => new(Value);
    }
    public class SkillLevelObjectValidator : AbstractValidator<SkillLevelObject>
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

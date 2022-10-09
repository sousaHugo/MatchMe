using FluentValidation;
using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Domain.ValueObjects.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record SkillLevelObject
    {
        private SkillLevelObjectValidator _validator = new();
        public SkillLevelObject(SkillLevelEnum Value)
        {
            this.Value = Value;

            var validationResult = _validator.Validate(this);
            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(SkillLevelObject)} Domain:", validationResult.ToDomainEntityValidationException());

        }
        public SkillLevelEnum Value { get; }

        public static implicit operator SkillLevelEnum(SkillLevelObject TextObject) => TextObject.Value;

        public static implicit operator SkillLevelObject(SkillLevelEnum Value) => new(Value);
    }
}

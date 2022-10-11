using FluentValidation;
using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Match.Domain.Entities.ValueObjects
{
    public record MatchStatusObject
    {
        private readonly MatchStatusObjectValidator _validator = new();
        public MatchStatusObject(MatchStatusEnum Value)
        {
            this.Value = Value;

            var validationResult = _validator.Validate(this);
            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(MatchStatusObject)} Domain:", validationResult.ToDomainEntityValidationException());
        }
        public MatchStatusEnum Value { get; }

        public static implicit operator MatchStatusEnum(MatchStatusObject TextObject) => TextObject.Value;

        public static implicit operator MatchStatusObject(MatchStatusEnum Value) => new(Value);
    }
    public class MatchStatusObjectValidator : Validator<MatchStatusObject>
    {
        public MatchStatusObjectValidator()
        {
            RuleFor(r => r.Value).NotNull().IsInEnum();
        }
    }
}

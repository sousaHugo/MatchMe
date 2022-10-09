using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Domain.ValueObjects.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record GenderObject
    {
        private GenderObjectValidator _validator = new();
        public GenderObject(GenderEnum Value)
        {
            this.Value = Value;

            var validationResult = _validator.Validate(this);
            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(GenderObject)} Domain:", validationResult.ToDomainEntityValidationException());

        }
        public GenderEnum Value { get; }

        public static implicit operator GenderEnum(GenderObject TextObject) => TextObject.Value;

        public static implicit operator GenderObject(GenderEnum Value) => new(Value);
    }
}

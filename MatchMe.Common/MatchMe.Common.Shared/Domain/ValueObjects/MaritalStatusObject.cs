using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Domain.ValueObjects.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record MaritalStatusObject
    {
        private MaritalStatusObjectValidator _validator = new();
        private MaritalStatusObject()
        {
            var validationResult = _validator.Validate(this);
            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(MaritalStatusObject)} Domain:", validationResult.ToDomainEntityValidationException());
        }
        public MaritalStatusObject(MaritalStatusEnum Value) 
            :base()
        {
            this.Value = Value;
        }
        public MaritalStatusEnum Value { get; }

        public static implicit operator MaritalStatusEnum(MaritalStatusObject TextObject) => TextObject.Value;

        public static implicit operator MaritalStatusObject(MaritalStatusEnum Value) => new(Value);
    }
    
}

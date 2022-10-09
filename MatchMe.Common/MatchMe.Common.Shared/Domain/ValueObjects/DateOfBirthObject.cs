using MatchMe.Common.Shared.Domain.ValueObjects.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record DateOfBirthObject
    {
        private DateOfBirthObjectValidator _validator = new();
        public DateOfBirthObject(DateTime Value) 
        {
            this.Value = Value;

            var validationResult = _validator.Validate(this);
            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(DateOfBirthObject)} Domain:", validationResult.ToDomainEntityValidationException());

        }
        public DateTime Value { get; }
      
        public static implicit operator DateTime(DateOfBirthObject TextObject) => TextObject.Value;

        public static implicit operator DateOfBirthObject(DateTime Value) => new(Value);
    }
}

using FluentValidation;
using MatchMe.Common.Shared.Domain.ValueObjects.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record CitizenCardNumberObject
    {
        private CitizenCardNumbertObjectValidator _validator = new();
        private CitizenCardNumberObject()
        {
            var validationResult = _validator.Validate(this);
            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(CitizenCardNumberObject)} Domain:", validationResult.ToDomainEntityValidationException());
        }
        public CitizenCardNumberObject(string Value)
            :base()
        {
            this.Value = Value;
        }
        public string Value { get; }

        public static implicit operator string(CitizenCardNumberObject TextObject) => TextObject.Value;

        public static implicit operator CitizenCardNumberObject(string Value) => new(Value);
    }
  
}

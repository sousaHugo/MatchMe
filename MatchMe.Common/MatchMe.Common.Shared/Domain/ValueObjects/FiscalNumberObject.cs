using MatchMe.Common.Shared.Domain.ValueObjects.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record FiscalNumberObject
    {
        private FiscalNumberObjectValidator _validator = new();
        private FiscalNumberObject()
        {
            var validationResult = _validator.Validate(this);
            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(FiscalNumberObject)} Domain:", validationResult.ToDomainEntityValidationException());
        }
        public FiscalNumberObject(string Value)
            :base()
        {
            this.Value = Value;
        }
        public string Value { get; }

        public static implicit operator string(FiscalNumberObject TextObject) => TextObject.Value;

        public static implicit operator FiscalNumberObject(string Value) => new(Value);
    }
}

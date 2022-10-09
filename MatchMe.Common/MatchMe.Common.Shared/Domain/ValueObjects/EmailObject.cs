using MatchMe.Common.Shared.Domain.ValueObjects.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Common.Shared.Domain.ValueObjects
{
    public record EmailObject
    {
        private EmailObjectValidator _validator = new();
        public EmailObject(string Value)
        {
            this.Value = Value;

            var validationResult = _validator.Validate(this);
            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(EmailObject)} Domain:", validationResult.ToDomainEntityValidationException());

        }
        public string Value { get; }
      
        public static implicit operator string(EmailObject TextObject) => TextObject.Value;

        public static implicit operator EmailObject(string Value) => new(Value);
    }
}

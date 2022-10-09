using FluentValidation;
using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Opportunities.Domain.Entities.ValueObjects
{
    public record OpportunityStatusObject
    {
        private readonly OpportunityStatusObjectValidator _validator = new();
        public OpportunityStatusObject(OpportunityStatusEnum Value)
        {
            this.Value = Value;

            var validationResult = _validator.Validate(this);
            if(!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(OpportunityStatusObject)} Domain:", validationResult.ToDomainEntityValidationException());
        }
        public OpportunityStatusEnum Value { get; }

        public static implicit operator OpportunityStatusEnum(OpportunityStatusObject TextObject) => TextObject.Value;

        public static implicit operator OpportunityStatusObject(OpportunityStatusEnum Value) => new(Value);
    }
    public class OpportunityStatusObjectValidator : Validator<OpportunityStatusObject>
    {
        public OpportunityStatusObjectValidator()
        {
            RuleFor(r => r.Value).NotNull().IsInEnum();
        }
    }
}

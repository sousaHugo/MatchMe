using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Opportunities.Domain.Entities.Validators;

namespace MatchMe.Opportunities.Domain.Entities.Extensions
{
    public static class OpportunitySkillExtension
    {
        private static OpportunitySkillValidator _validator = new();

        public static void Validate(this OpportunitySkill OpportunitySkill)
        {
            var validationResult = _validator.Validate(OpportunitySkill);

            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(OpportunitySkill)} Domain:", validationResult.ToDomainEntityValidationException());
        }
    }
}

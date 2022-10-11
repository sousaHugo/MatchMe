using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Match.Domain.Entities.Validators;

namespace MatchMe.Match.Domain.Entities.Extensions
{
    public static class MatchExtension
    {
        private static MatchValidator _validator = new();

        public static void Validate(this Match Match)
        {
            var validationResult = _validator.Validate(Match);

            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(Match)} Domain:", validationResult.ToDomainEntityValidationException());
        }
    }
}

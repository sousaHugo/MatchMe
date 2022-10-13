using MatchMe.Candidates.Domain.Entities.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Candidates.Domain.Entities.Extensions
{
    public static class CandidateEducationExtension
    {
        private static CandidateEducationValidator _validator = new();
        
        public static void Validate(this CandidateEducation CandidateEducation)
        {
            var validationResult = _validator.Validate(CandidateEducation);

            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(CandidateEducation)} Domain:", validationResult.ToDomainEntityValidationException());
        }
    }
}

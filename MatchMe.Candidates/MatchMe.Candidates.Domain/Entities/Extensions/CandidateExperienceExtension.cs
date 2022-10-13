using MatchMe.Candidates.Domain.Entities.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Candidates.Domain.Entities.Extensions
{
    public static class CandidateExperienceExtension
    {
        private static CandidateExperienceValidator _validator = new();
        
        public static void Validate(this CandidateExperience CandidateExperience)
        {
            var validationResult = _validator.Validate(CandidateExperience);

            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(CandidateExperience)} Domain:", validationResult.ToDomainEntityValidationException());
        }
    }
}

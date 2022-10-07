using MatchMe.Candidates.Domain.Entities.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Candidates.Domain.Entities.Extensions
{
    public static class CandidateExtension
    {
        private static CandidateValidator _validator = new();
        
        public static void Validate(this Candidate Candidate)
        {
            var validationResult = _validator.Validate(Candidate);

            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(Candidate)} Domain:", validationResult.ToDomainEntityValidationException());
        }
    }
}

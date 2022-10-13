using MatchMe.Candidates.Domain.Entities.Validators;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;

namespace MatchMe.Candidates.Domain.Entities.Extensions
{
    public static class CandidateSkillExtension
    {
        private static CandidateSkillValidator _validator = new();
        
        public static void Validate(this CandidateSkill CandidateSkill)
        {
            var validationResult = _validator.Validate(CandidateSkill);

            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(CandidateSkill)} Domain:", validationResult.ToDomainEntityValidationException());
        }
    }
}

using MatchMe.Candidates.Application.Dto.CandidatesSkill.Validators;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Candidates.Application.Dto.Candidates.Validators
{
    public class CandidateUpdateWithDetailsDtoValidator : Validator<CandidateUpdateWithDetailsDto>
    {
        public CandidateUpdateWithDetailsDtoValidator()
            : base()
        {
            RuleFor(x => x).SetValidator(new CandidateBaseDtoValidator());
            RuleForEach(x => x.Skills).SetValidator(new CandidateSkillBaseDtoValidator());
        }

    }
}

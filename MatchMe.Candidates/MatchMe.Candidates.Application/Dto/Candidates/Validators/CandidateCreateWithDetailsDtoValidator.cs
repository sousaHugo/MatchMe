using FluentValidation;
using MatchMe.Candidates.Application.Dto.CandidatesSkill.Validators;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Candidates.Application.Dto.Candidates.Validators
{
    public class CandidateCreateWithDetailsDtoValidator : Validator<CandidateCreateWithDetailsDto>
    {
        public CandidateCreateWithDetailsDtoValidator()
            : base()
        {
            RuleFor(x => x).SetValidator(new CandidateBaseDtoValidator());
            RuleForEach(x => x.Skills).SetValidator(new CandidateSkillBaseDtoValidator());
        }

    }
}

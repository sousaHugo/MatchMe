using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Candidates.Application.Dto.CandidatesSkill.Validators
{
    public class CandidateSkillUpdateDtoValidator : Validator<CandidateSkillUpdateDto>
    {
        public CandidateSkillUpdateDtoValidator(long? Id = null)
            : base()
        {
            RuleFor(x => x).SetValidator(new CandidateSkillBaseDtoValidator());

            if (Id.HasValue)
                RuleFor(x => x.Id).Must(m => m == Id.Value).WithMessage($"Id;Id doesn't match with the Skill to update.").WithName("Id");
           
        }
    }
}

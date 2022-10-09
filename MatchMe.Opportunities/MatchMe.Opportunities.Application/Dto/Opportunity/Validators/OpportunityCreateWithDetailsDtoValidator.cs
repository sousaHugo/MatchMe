using MatchMe.Common.Shared.FluentValidation;
using MatchMe.Opportunities.Application.Dto.OpportunitySkill.Validators;

namespace MatchMe.Opportunities.Application.Dto.Opportunity.Validators
{
    public class OpportunityCreateWithDetailsDtoValidator : Validator<OpportunityCreateWithDetailsDto>
    {
        public OpportunityCreateWithDetailsDtoValidator()
        {
            RuleFor(r => r).SetValidator(new OpportunityBaseDtoValidator());
            RuleForEach(x => x.Skills).SetValidator(new OpportunitySkillBaseDtoValidator());
        }
    }
}

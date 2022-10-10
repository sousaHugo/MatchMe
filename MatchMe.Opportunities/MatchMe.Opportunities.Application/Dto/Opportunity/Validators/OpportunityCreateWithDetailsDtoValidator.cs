using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;
using MatchMe.Opportunities.Application.Dto.OpportunitySkill.Validators;

namespace MatchMe.Opportunities.Application.Dto.Opportunity.Validators
{
    public class OpportunityCreateWithDetailsDtoValidator : Validator<OpportunityCreateWithDetailsDto>
    {
        public OpportunityCreateWithDetailsDtoValidator()
        {
            RuleFor(r => r).SetValidator(new OpportunityBaseDtoValidator());
            RuleFor(r => r.Skills).Must(s => s.DistinctBy(d => d.Name).Count() == s.Count()).WithMessage("One or more Skills are duplicated.");
            RuleForEach(x => x.Skills).SetValidator(new OpportunitySkillBaseDtoValidator());
        }
    }
}

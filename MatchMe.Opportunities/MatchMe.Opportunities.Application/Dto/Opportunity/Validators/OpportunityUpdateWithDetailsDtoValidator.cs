using FluentValidation;
using IdGen;
using MatchMe.Common.Shared.FluentValidation;
using MatchMe.Opportunities.Application.Dto.OpportunitySkill.Validators;

namespace MatchMe.Opportunities.Application.Dto.Opportunity.Validators
{
    public class OpportunityUpdateWithDetailsDtoValidator : Validator<OpportunityUpdateWithDetailsDto>
    {
        public OpportunityUpdateWithDetailsDtoValidator(long? Id = null)
        {
            RuleFor(r => r).SetValidator(new OpportunityBaseDtoValidator());
            When(a => Id is not null, () =>
            {
                RuleFor(a => a.Id).Must(a => a == Id.Value).WithMessage($"Id doesn't match with the Opportunity to update.").WithName("Id");
            });
            RuleFor(r => r.Skills).Must(s => s.DistinctBy(d => d.Name).Count() != s.Count()).WithMessage("One or more Skills are duplicated.");
            RuleForEach(x => x.Skills).SetValidator(new OpportunitySkillBaseDtoValidator());
        }
    }
}

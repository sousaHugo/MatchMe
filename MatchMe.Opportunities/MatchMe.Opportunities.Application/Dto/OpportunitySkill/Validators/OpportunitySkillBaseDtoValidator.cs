using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Opportunities.Application.Dto.OpportunitySkill.Validators
{
    public class OpportunitySkillBaseDtoValidator : Validator<OpportunitySkillBaseDto>
    {
        public OpportunitySkillBaseDtoValidator()
        {
            RuleFor(r => r.Name).NotNullOrEmpty();
            RuleFor(r => r.Level).NotNull();
            When(a => a.MinExperience is not null, () =>
            {
                RuleFor(r => r.MinExperience).GreaterThan(0).LessThanOrEqualTo(a => a.MaxExperience);
            });
            When(a => a.MaxExperience is not null, () =>
            {
                RuleFor(r => r.MaxExperience).GreaterThan(0).GreaterThanOrEqualTo(a => a.MinExperience);
            });
           
        }
    }
}

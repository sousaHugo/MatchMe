using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Opportunities.Application.Dto.Opportunity.Validators
{
    public class OpportunityBaseDtoValidator : Validator<OpportunityBaseDto>
    {
        public OpportunityBaseDtoValidator()
        {
            RuleFor(r => r.Title).NotNullOrEmpty();
            RuleFor(r => r.Description).NotNullOrEmpty();
            RuleFor(r => r.ClientId).NotNullOrEmpty();
            RuleFor(r => r.Responsible).NotNullOrEmpty();
            RuleFor(r => r.Location).NotNullOrEmpty();

            RuleFor(r => r.BeginDate)
              .NotNull()
              .LessThanOrEqualTo(a => a.EndDate);
            RuleFor(r => r.EndDate).NotNull();

            When(a => a.MinSalaryYear is not null && a.MaxSalaryYear is not null, () => {
                RuleFor(r => r.MinSalaryYear)
                .NotNull()
                .LessThanOrEqualTo(a => a.MaxSalaryYear);

                RuleFor(r => r.MaxSalaryYear)
                .NotNull()
                .GreaterThanOrEqualTo(a => a.MinSalaryYear);
            });

            When(a => a.MinExperienceMonth is not null && a.MaxExperienceMonth is not null, () => {
                RuleFor(r => r.MinExperienceMonth)
                .NotNull()
                .LessThanOrEqualTo(a => a.MaxExperienceMonth);

                RuleFor(r => r.MaxExperienceMonth)
                .NotNull()
                .GreaterThanOrEqualTo(a => a.MinExperienceMonth);
            });

        }
    }
}

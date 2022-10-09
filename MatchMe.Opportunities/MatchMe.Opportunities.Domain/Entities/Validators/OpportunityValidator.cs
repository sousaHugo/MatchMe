using FluentValidation;
using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Opportunities.Domain.Entities.Validators
{
    public class OpportunityValidator : Validator<Opportunity>
    {
        public OpportunityValidator()
        {
            RuleFor(r => r.ClientId).NotNullOrEmpty();
            RuleFor(r => r.Descritption).NotNullOrEmpty();
            RuleFor(r => r.Title).NotNullOrEmpty();
            RuleFor(r => r.Reference).NotNullOrEmpty();
            RuleFor(r => r.Responsible).NotNullOrEmpty();
            RuleFor(r => r.Location).NotNullOrEmpty();
            RuleFor(r => r.Status).NotNull();
            RuleFor(r => r.BeginDate)
                .NotNull()
                .LessThanOrEqualTo(a => a.EndDate);
            RuleFor(r => r.EndDate).NotNull();

            When(a => a.MinSalaryYear is not null && a.MaxSalaryYear is not null,() =>{
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


            RuleFor(r => r.Skills).Must(skills => skills.DistinctBy(a => a.Name).Count() == skills.Count)
                .WithMessage("One or more Skills are duplicated.");

        }
    }
}

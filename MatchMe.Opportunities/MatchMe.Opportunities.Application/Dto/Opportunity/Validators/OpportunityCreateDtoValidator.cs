using MatchMe.Common.Shared.FluentValidation;

namespace MatchMe.Opportunities.Application.Dto.Opportunity.Validators
{
    public class OpportunityCreateDtoValidator : Validator<OpportunityCreateDto>
    {
        public OpportunityCreateDtoValidator()
        {
            RuleFor(r => r).SetValidator(new OpportunityBaseDtoValidator());
        }
    }
}

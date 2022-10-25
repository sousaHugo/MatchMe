using MatchMe.Common.Shared.Exceptions;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Opportunities.Domain.Entities.Validators;
using MatchMe.Opportunities.Integration.Messages;

namespace MatchMe.Opportunities.Domain.Entities.Extensions
{
    public static class OpportunityExtension
    {
        private static OpportunityValidator _validator = new();

        public static void Validate(this Opportunity Opportunity)
        {
            var validationResult = _validator.Validate(Opportunity);

            if (!validationResult.IsValid)
                throw new DomainEntitiesException($"The following errors ocurred on the {nameof(Opportunity)} Domain:", validationResult.ToDomainEntityValidationException());
        }

        public static OpportunityCreatedMessageDto AsOpportunityCreatedDto(this Opportunity Opportunity)
        {
            return new OpportunityCreatedMessageDto(Opportunity.Id, Opportunity.Title, Opportunity.Reference, Opportunity.Description,
                Opportunity.ClientId, Opportunity.Responsible, Opportunity.Location, Opportunity.Status, Opportunity.BeginDate,
                Opportunity.EndDate, Opportunity.MinSalaryYear, Opportunity.MaxSalaryYear, Opportunity.MinExperienceMonth,
                Opportunity.MaxExperienceMonth, Opportunity.Skills.Select(a => new OpportunitySkillCreatedMessageDto(a.Id, a.Name,
                a.MinExperience, a.MaxExperience, a.Level, a.Mandatory)));
        }
    }
}

using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Integration.Messages;

namespace MatchMe.Opportunities.Application.Mapping
{
    public static partial class ApplicationMappingExtension
    {
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

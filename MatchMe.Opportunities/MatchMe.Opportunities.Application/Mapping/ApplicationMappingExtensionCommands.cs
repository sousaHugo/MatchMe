using MatchMe.Opportunities.Application.Commands;
using MatchMe.Opportunities.Application.Commands.Models;
using MatchMe.Opportunities.Application.Dto.Opportunity;
using MatchMe.Opportunities.Application.Dto.OpportunitySkill;

namespace MatchMe.Opportunities.Application.Mapping
{
    public static partial class ApplicationMappingExtension
    {
        public static CreateOpportunityCommand AsCreateOpportunityCommand(this OpportunityCreateDto Opportunity)
        {
            return new CreateOpportunityCommand(
                Opportunity.Title,
                Opportunity.Description,
                Opportunity.ClientId,
                Opportunity.Responsible,
                Opportunity.Location,
                Opportunity.BeginDate,
                Opportunity.EndDate,
                Opportunity.MinSalaryYear,
                Opportunity.MaxSalaryYear,
                Opportunity.MinExperienceMonth,
                Opportunity.MaxExperienceMonth
                );
        }
        public static CreateOpportunityWithDetailsCommand AsCreateOpportunityWithDetailsCommand(this OpportunityCreateWithDetailsDto Opportunity)
        {
            return new CreateOpportunityWithDetailsCommand(
                Opportunity.Title,
                Opportunity.Description,
                Opportunity.ClientId,
                Opportunity.Responsible,
                Opportunity.Location,
                Opportunity.BeginDate,
                Opportunity.EndDate,
                Opportunity.MinSalaryYear,
                Opportunity.MaxSalaryYear,
                Opportunity.MinExperienceMonth,
                Opportunity.MaxExperienceMonth,
                Opportunity.Skills.AsOpportunitySkillCommandModel()
                );
        }
        public static UpdateOpportunityCommand AsUpdateOpportunityCommand(this OpportunityUpdateWithDetailsDto Opportunity)
        {
            return new UpdateOpportunityCommand(
                Opportunity.Id,
                Opportunity.Title,
                Opportunity.Description,
                Opportunity.ClientId,
                Opportunity.Responsible,
                Opportunity.Location,
                Opportunity.BeginDate,
                Opportunity.EndDate,
                Opportunity.MinSalaryYear,
                Opportunity.MaxSalaryYear,
                Opportunity.MinExperienceMonth,
                Opportunity.MaxExperienceMonth,
                Opportunity.Skills.AsOpportunitySkillCommandModel()
                );
        }
        public static OpportunitySkillCommandModel AsOpportunitySkillCommandModel(this OpportunitySkillCreatelDto Skill)
        {
            return new OpportunitySkillCommandModel(Skill.Name, Skill.MinExperience, Skill.MaxExperience, Skill.Level,
                Skill.Mandatory);
        }
        public static IEnumerable<OpportunitySkillCommandModel> AsOpportunitySkillCommandModel(this IEnumerable<OpportunitySkillCreatelDto> Skill)
        {
            return Skill.AsOpportunitySkillCommandModel();
        }
        public static OpportunitySkillCommandModel AsOpportunitySkillCommandModel(this OpportunitySkillUpdatelDto Skill)
        {
            return new OpportunitySkillCommandModel(Skill.Name, Skill.MinExperience, Skill.MaxExperience, Skill.Level,
                Skill.Mandatory);
        }
        public static IEnumerable<OpportunitySkillCommandModel> AsOpportunitySkillCommandModel(this IEnumerable<OpportunitySkillUpdatelDto> Skill)
        {
            return Skill.AsOpportunitySkillCommandModel();
        }
    }
}

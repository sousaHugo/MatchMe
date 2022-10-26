using MatchMe.Opportunities.Domain.Entities;
using MatchMe.Opportunities.Domain.Events.Models;

namespace MatchMe.Opportunities.Domain.Mapping
{
    public static class DomainMappingExtension
    {
        public static OpportunityDEModel AsOpportunityDEModel(this Opportunity Opportunity)
        {
            return new OpportunityDEModel()
            {
               Id = Opportunity.Id,
               BeginDate = Opportunity.BeginDate,
               ClientId = Opportunity.ClientId,
               Description = Opportunity.Description,
               EndDate = Opportunity.EndDate,
               Location = Opportunity.Location,
               MaxExperienceMonth = Opportunity.MaxExperienceMonth,
               MaxSalaryYear = Opportunity.MaxSalaryYear,
               MinExperienceMonth = Opportunity.MinExperienceMonth, 
               MinSalaryYear = Opportunity.MinSalaryYear,
               Reference = Opportunity.Reference,
               Responsible = Opportunity.Responsible,
               Skills = Opportunity.Skills.AsOpportunitySkillDEModel(),
               Status = Opportunity.Status,
               Title = Opportunity.Title
            };
        }

        public static OpportunitySkillDEModel AsOpportunitySkillDEModel(this OpportunitySkill Skill)
        {
            return new OpportunitySkillDEModel()
            {
                Id = Skill.Id,
                Level = Skill.Level,
                Mandatory = Skill.Mandatory,
                MaxExperience = Skill.MaxExperience,
                MinExperience = Skill.MinExperience,
                Name = Skill.Name
            };
        }
        public static IEnumerable<OpportunitySkillDEModel> AsOpportunitySkillDEModel(this IEnumerable<OpportunitySkill> Skill)
        {
            return Skill.Select(a => a.AsOpportunitySkillDEModel());
        }
    }
}

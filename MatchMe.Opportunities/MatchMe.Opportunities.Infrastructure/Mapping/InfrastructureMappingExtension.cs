using MatchMe.Opportunities.Application.Dto.Opportunity;
using MatchMe.Opportunities.Application.Dto.OpportunitySkill;
using MatchMe.Opportunities.Infrastructure.EF.Models;

namespace MatchMe.Opportunities.Infrastructure.Mapping
{
    public static class InfrastructureMappingExtension
    {
        public static OpportunityGetDto AsOpportunityGetDto(this OpportunityReadModel OpportunityReadModel)
        {
            return new OpportunityGetDto()
            {
                Id = OpportunityReadModel.Id,
                BeginDate = OpportunityReadModel.BeginDate,
                ClientId = OpportunityReadModel.ClientId,
                Description = OpportunityReadModel.Description,
                EndDate = OpportunityReadModel.EndDate,
                Location = OpportunityReadModel.Location,
                MaxExperienceMonth = OpportunityReadModel.MaxExperienceMonth,
                MaxSalaryYear = OpportunityReadModel.MaxSalaryYear,
                MinExperienceMonth = OpportunityReadModel.MinExperienceMonth,
                MinSalaryYear = OpportunityReadModel.MinSalaryYear,
                Reference = OpportunityReadModel.Reference,
                Responsible = OpportunityReadModel.Responsible,
                Status = OpportunityReadModel.Status,
                Title = OpportunityReadModel.Title,
            };
        }

        public static OpportunityDto AsOpportunityDto(this OpportunityReadModel OpportunityReadModel)
        {
            return new OpportunityDto()
            {
                Id = OpportunityReadModel.Id,
                BeginDate = OpportunityReadModel.BeginDate,
                ClientId = OpportunityReadModel.ClientId,
                Description = OpportunityReadModel.Description,
                EndDate = OpportunityReadModel.EndDate,
                Location = OpportunityReadModel.Location,
                MaxExperienceMonth = OpportunityReadModel.MaxExperienceMonth,
                MaxSalaryYear = OpportunityReadModel.MaxSalaryYear,
                MinExperienceMonth = OpportunityReadModel.MinExperienceMonth,
                MinSalaryYear = OpportunityReadModel.MinSalaryYear,
                Reference = OpportunityReadModel.Reference,
                Responsible = OpportunityReadModel.Responsible,
                Status = OpportunityReadModel.Status,
                Title = OpportunityReadModel.Title,
                Skills = OpportunityReadModel.Skills.AsOpportunitySkillDto()
            };
        }

        public static OpportunitySkillDto AsOpportunitySkillDto(this OpportunitySkillReadModel OpportunitySkillReadModel)
        {
            return new OpportunitySkillDto()
            {
                Id = OpportunitySkillReadModel.Id,
                Mandatory = OpportunitySkillReadModel.Mandatory,
                Name = OpportunitySkillReadModel.Name,
                MinExperience = OpportunitySkillReadModel.MinExperience,
                MaxExperience = OpportunitySkillReadModel.MaxExperience,
                OpportunityId = OpportunitySkillReadModel.OpportunityId
            };
        }
        public static IEnumerable<OpportunitySkillDto> AsOpportunitySkillDto(this IEnumerable<OpportunitySkillReadModel> OpportunitySkillReadModelList)
        {
            return OpportunitySkillReadModelList.Select(a => a.AsOpportunitySkillDto()).AsEnumerable();
        }

    }
}

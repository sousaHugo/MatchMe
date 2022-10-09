using MatchMe.Opportunities.Application.Dto.Opportunity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMe.Opportunities.Infrastructure.EF.Models.Mapping
{
    public static class OpportunityReadModelMappingConfig
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
    }
}

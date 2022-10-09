using MatchMe.Opportunities.Application.Dto;

namespace MatchMe.Opportunities.Infrastructure.EF.Models.Mapping
{
    public static class OpportunitySkillReadModelMappingConfig
    {
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

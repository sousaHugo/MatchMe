using MatchMe.Candidates.Application.Dto;

namespace MatchMe.Candidates.Infrastructure.EF.Models.Mapping
{
    public static class CandidateSkillReadModelMappingConfig
    {
        public static CandidateSkillGetDto AsCandidateSkillGetDto(this CandidateSkillReadModel CandidateSkillReadModel)
        {
            return new CandidateSkillGetDto()
            {
                Id = CandidateSkillReadModel.Id,
                Experience = CandidateSkillReadModel.Experience,
                Level = CandidateSkillReadModel.Level,
                Name = CandidateSkillReadModel.Name 
            };
        }
    }
}

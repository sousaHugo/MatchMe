using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Opportunities.Application.Dto.OpportunitySkill
{
    public class OpportunitySkillBaseDto
    {
        public string Name { get; set; }
        public int? MinExperience { get; set; }
        public int? MaxExperience { get; set; }
        public SkillLevelEnum Level { get; set; }
        public bool Mandatory { get; set; }

    }
}

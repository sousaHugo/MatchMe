using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Candidates.Application.Dto.CandidatesSkill
{
    public class CandidateSkillBaseDto
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        public SkillLevelEnum Level { get; set; }
    }
}

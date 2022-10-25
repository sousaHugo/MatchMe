using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Match.Integration.Messages
{
    public class CandidateCreatedSkillMessageDto
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        public SkillLevelEnum Level { get; set; }
        public long CandidateId { get; set; }
    }
}

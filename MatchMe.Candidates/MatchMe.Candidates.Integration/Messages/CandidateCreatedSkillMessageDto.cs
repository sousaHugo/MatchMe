using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Candidates.Integration.Messages
{
    public class CandidateCreatedSkillMessageDto
    {
        public CandidateCreatedSkillMessageDto(long Id, string Name, int Experience, SkillLevelEnum Level)
        {
            this.Id = Id;
            this.Name = Name;
            this.Experience = Experience;
            this.Level = Level;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public SkillLevelEnum Level { get; set; }
    }
}

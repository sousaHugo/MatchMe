using MatchMe.Common.Shared.Constants.Enums;
namespace MatchMe.Candidates.Domain.Events.Models
{
    public class CandidateSkillDEModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public SkillLevelEnum Level { get; set; }
    }
}

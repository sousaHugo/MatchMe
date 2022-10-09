using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Candidates.Infrastructure.EF.Models
{
    public class CandidateSkillReadModel : BaseModel
    {
        public string Name { get; }
        public int Experience { get; }
        public SkillLevelEnum Level { get;  }
        public CandidateReadModel Candidate { get; }
        public long CandidateId { get; }
    }
}

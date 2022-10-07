using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Candidates.Application.Commands.Candidates.Models
{
    public record CandidateSkillCommandWriteModel
    {
        public long Id { get; init; }    
        public string Name { get; init; }
        public int Experience { get; init; }
        public SkillLevelEnum Level { get; init; }
        public CandidateSkillCommandWriteModel(string Name, int Experience, SkillLevelEnum Level)
        {
            this.Name = Name;
            this.Experience = Experience;
            this.Level = Level;
        }
        public CandidateSkillCommandWriteModel(long Id, string Name, int Experience, SkillLevelEnum Level)
        {
            this.Id = Id;
            this.Name = Name;
            this.Experience = Experience;
            this.Level = Level;
        }
    }
}

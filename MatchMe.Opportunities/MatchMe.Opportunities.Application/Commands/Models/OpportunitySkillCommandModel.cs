using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Opportunities.Application.Commands.Models
{
    public record OpportunitySkillCommandModel
    {
        public long Id { get; init; }    
        public string Name { get; init; }
        public int? MinExperience { get; init; }
        public int? MaxExperience { get; init; }
        public SkillLevelEnum Level { get; init; }
        public bool Mandatory { get; init; }
        public OpportunitySkillCommandModel(string Name, int? MinExperience, int? MaxExperience,
            SkillLevelEnum Level, bool Mandatory)
        {
            this.Name = Name;
            this.MinExperience = MinExperience;
            this.MaxExperience = MaxExperience;
            this.Level = Level;
            this.Mandatory = Mandatory;
        }
        public OpportunitySkillCommandModel(long Id, string Name, int? MinExperience, int? MaxExperience,
            SkillLevelEnum Level, bool Mandatory)
        {
            this.Id = Id;
            this.Name = Name;
            this.MinExperience = MinExperience;
            this.MaxExperience = MaxExperience;
            this.Level = Level;
            this.Mandatory = Mandatory;
        }
    }
}

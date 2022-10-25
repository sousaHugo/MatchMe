using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Integration;

namespace MatchMe.Opportunities.Integration.Messages
{
    public class OpportunitySkillCreatedMessageDto : BaseMessageDto
    {
        public OpportunitySkillCreatedMessageDto(long Id, string Name, int? MinExperience, int? MaxExperience, SkillLevelEnum Level, bool Mandatory)
        {
            this.Id = Id;
            this.Name = Name;
            this.MinExperience = MinExperience;
            this.MaxExperience = MaxExperience;
            this.Level = Level;
            this.Mandatory = Mandatory;
        }
        public string Name { get; }
        public int? MinExperience { get; }
        public int? MaxExperience { get; }
        public SkillLevelEnum Level { get; }
        public bool Mandatory { get; init; }
    }
}

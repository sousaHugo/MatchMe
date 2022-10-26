using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Opportunities.Domain.Events.Models
{
    public  class OpportunitySkillDEModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? MinExperience { get; set; }
        public int? MaxExperience { get; set; }
        public SkillLevelEnum Level { get; set; }
        public bool Mandatory { get; set; }
    }
}

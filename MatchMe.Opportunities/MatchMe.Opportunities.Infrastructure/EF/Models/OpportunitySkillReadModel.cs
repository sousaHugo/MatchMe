using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Opportunities.Infrastructure.EF.Models
{
    public class OpportunitySkillReadModel
    {
        public long Id { get; }
        public string Name { get; }
        public int? MinExperience { get; }
        public int? MaxExperience { get; }
        public SkillLevelEnum Level { get; }
        public bool Mandatory { get; init; }
        public OpportunityReadModel Opportunity { get; }
        public long OpportunityId { get; }
    }
}

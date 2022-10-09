namespace MatchMe.Opportunities.Infrastructure.EF.Models
{
    public class OpportunitySkillReadModel
    {
        public long Id { get; set; }
        public string Name { get; }
        public int? MinExperience { get; }
        public int? MaxExperience { get; }
        public bool Mandatory { get; init; }
        public OpportunityReadModel Opportunity { get; set; }
        public long OpportunityId { get; set; }
    }
}

namespace MatchMe.Opportunities.Infrastructure.EF.Models
{
    public class OpportunitySkillReadModel
    {
        public Guid Id { get; set; }
        public string Title { get; }
        public string Description { get; }
        public int Min_Experience { get; }
        public int Max_Experience { get; }
        public bool Mandatory { get; init; }
        public OpportunityReadModel Opportunity { get; set; }
    }
}

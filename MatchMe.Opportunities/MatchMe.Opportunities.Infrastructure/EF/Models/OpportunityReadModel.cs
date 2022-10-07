namespace MatchMe.Opportunities.Infrastructure.EF.Models
{
    public class OpportunityReadModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<OpportunitySkillReadModel> Skills { get; set; }
        public int Version { get; set; }
    }
}

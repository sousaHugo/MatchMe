namespace MatchMe.Opportunities.Application.Dto
{
    public class OpportunitySkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; }
        public int Experience { get; }
        public bool Mandatory { get; init; }

    }
}

namespace MatchMe.Opportunities.Application.Dto
{
    public class OpportunityDto
    {
        public Guid Id { get; set; }  
        public string Title { get; set; }
        public string Description { get; set; } 

        public IEnumerable<OpportunitySkillDto> Skills { get; set; }
    }
}

namespace MatchMe.Opportunities.Application.Dto
{
    public class OpportunityDto : OpportunityBaseDto
    {
        public long Id { get; set; }
        public IEnumerable<OpportunitySkillDto> Skills { get; set; }
    }
}

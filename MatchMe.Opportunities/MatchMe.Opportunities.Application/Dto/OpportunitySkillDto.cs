namespace MatchMe.Opportunities.Application.Dto
{
    public class OpportunitySkillDto : OpportunitySkillBaseDto
    {
        public long Id { get; set; }
        public long OpportunityId { get; set; }
    }
}

using MatchMe.Opportunities.Application.Dto.OpportunitySkill;

namespace MatchMe.Opportunities.Application.Dto.Opportunity
{
    public class OpportunityCreateWithDetailsDto : OpportunityBaseDto
    {
        public IEnumerable<OpportunitySkillCreatelDto> Skills { get; set; }
    }
}

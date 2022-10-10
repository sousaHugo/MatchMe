using MatchMe.Opportunities.Application.Dto.OpportunitySkill;

namespace MatchMe.Opportunities.Application.Dto.Opportunity
{
    public class OpportunityUpdateWithDetailsDto : OpportunityBaseDto
    {
        public long Id { get; set; }
        public IEnumerable<OpportunitySkillUpdatelDto> Skills { get; set; }
    }
}

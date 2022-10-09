using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Opportunities.Application.Dto.OpportunitySkill;

namespace MatchMe.Opportunities.Application.Dto.Opportunity
{
    public class OpportunityDto : OpportunityBaseDto
    {
        public long Id { get; set; }
        public string Reference { get; set; }
        public OpportunityStatusEnum Status { get; set; }
        public IEnumerable<OpportunitySkillDto> Skills { get; set; }
    }
}

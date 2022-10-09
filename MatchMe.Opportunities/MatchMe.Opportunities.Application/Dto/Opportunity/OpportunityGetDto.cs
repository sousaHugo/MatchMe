using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Opportunities.Application.Dto.Opportunity
{
    public class OpportunityGetDto : OpportunityBaseDto
    {
        public long Id { get; set; }
        public string Reference { get; set; }
        public OpportunityStatusEnum Status { get; set; }
    }
}

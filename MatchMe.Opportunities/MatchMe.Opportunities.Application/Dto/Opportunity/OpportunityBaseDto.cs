using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Opportunities.Application.Dto.Opportunity
{
    public class OpportunityBaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string Responsible { get; set; }
        public string Location { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? MinSalaryYear { get; set; }
        public decimal? MaxSalaryYear { get; set; }
        public int? MinExperienceMonth { get; set; }
        public int? MaxExperienceMonth { get; set; }
    }
}

using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Match.Infrastructure.EF.Models
{
    internal class MatchReadModel
    {
        public long Id { get; set; }
        public long CandidateId { get; set; }
        public string CandidateName { get; set; }
        public long OpportunityId { get; set; }
        public string OpportunityTitle { get; set; }
        public bool Automatic { get; set; }
        public decimal Percentage { get; set; }
        public MatchStatusEnum Status { get; set; }
    }
}

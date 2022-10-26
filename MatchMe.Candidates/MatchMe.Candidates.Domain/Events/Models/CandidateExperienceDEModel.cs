namespace MatchMe.Candidates.Domain.Events.Models
{
    public class CandidateExperienceDEModel
    {
        public long Id { get; set; }
        public string Role { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string Responsibilities { get; set; }
    }
}

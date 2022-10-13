namespace MatchMe.Candidates.Infrastructure.EF.Models
{
    public class CandidateExperienceReadModel : BaseModel
    {
        public string Role { get; }
        public string Company { get; }
        public string City { get;  }
        public string Country { get; }
        public DateTime BeginDate { get; }
        public DateTime? EndDate { get; }
        public string Description { get; }
        public string Responsibilities { get; }
        public CandidateReadModel Candidate { get; }
        public long CandidateId { get; }
    }
}

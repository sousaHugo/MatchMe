namespace MatchMe.Candidates.Infrastructure.EF.Models
{
    public class CandidateEducationReadModel : BaseModel
    {
        public string Title { get; }
        public string Organization { get; }
        public AddressReadModel Address { get;  }
        public DateTime BeginDate { get; }
        public DateTime? EndDate { get; }
        public string Description { get; }
        public CandidateReadModel Candidate { get; }
        public long CandidateId { get; }
    }
}

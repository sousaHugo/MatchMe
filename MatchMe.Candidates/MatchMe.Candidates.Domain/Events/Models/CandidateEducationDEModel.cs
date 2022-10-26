namespace MatchMe.Candidates.Domain.Events.Models
{
    public class CandidateEducationDEModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Organization { get; set; }
        public AddressDEModel Address { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}

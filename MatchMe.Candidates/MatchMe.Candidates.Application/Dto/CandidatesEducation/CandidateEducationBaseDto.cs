namespace MatchMe.Candidates.Application.Dto.CandidatesEducation
{
    public class CandidateEducationBaseDto
    {
        public string Title { get; set; }
        public string Organization { get; set; }
        public CandidateEducationAddressDto Address { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}

namespace MatchMe.Candidates.Application.Dto.CandidatesExperience
{
    public  class CandidateExperienceBaseDto
    {
        public string Role { get; set; }
        public string Description { get; set; }
        public string Responsibilities { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

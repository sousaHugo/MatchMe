namespace MatchMe.Candidates.Application.Dto.Candidates
{
    public class CandidateUpdateWithDetailsDto : CandidateBaseDto
    {
        public long Id { get; set; }
        public List<CandidateSkillDto> Skills { get; set; }
    }
}

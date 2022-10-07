using MatchMe.Candidates.Application.Dto.CandidatesSkill;

namespace MatchMe.Candidates.Application.Dto
{
    public class CandidateSkillGetDto : CandidateSkillBaseDto
    {
        public long Id { get; set; }
        public long CandidateId { get; set; }
    }
}

using MatchMe.Candidates.Application.Dto.CandidatesSkill;

namespace MatchMe.Candidates.Application.Dto.Candidates
{
    public class CandidateCreateWithDetailsDto : CandidateCreateDto
    {
        public List<CandidateSkillBaseDto> Skills { get; set; }
    }
}

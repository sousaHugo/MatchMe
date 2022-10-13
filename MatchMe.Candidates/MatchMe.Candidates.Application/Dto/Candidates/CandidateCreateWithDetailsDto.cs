using MatchMe.Candidates.Application.Dto.CandidatesEducation;
using MatchMe.Candidates.Application.Dto.CandidatesExperience;
using MatchMe.Candidates.Application.Dto.CandidatesSkill;

namespace MatchMe.Candidates.Application.Dto.Candidates
{
    public class CandidateCreateWithDetailsDto : CandidateCreateDto
    {
        public List<CandidateSkillBaseDto> Skills { get; set; } = new();
        public List<CandidateExperienceBaseDto> Experiences { get; set; } = new();
        public List<CandidateEducationBaseDto> Educations { get; set; } = new();
    }
}

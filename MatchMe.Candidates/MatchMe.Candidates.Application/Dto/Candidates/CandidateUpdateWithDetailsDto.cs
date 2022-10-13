using MatchMe.Candidates.Application.Dto.CandidatesEducation;
using MatchMe.Candidates.Application.Dto.CandidatesExperience;

namespace MatchMe.Candidates.Application.Dto.Candidates
{
    public class CandidateUpdateWithDetailsDto : CandidateBaseDto
    {
        public long Id { get; set; }
        public List<CandidateSkillDto> Skills { get; set; } = new();
        public List<CandidateExperienceDto> Experiences { get; set; } = new();
        public List<CandidateEducationDto> Educations { get; set; } = new();
    }
}

using MatchMe.Candidates.Domain.Entities;

namespace MatchMe.Candidates.Application.Dto.CandidatesSkill.Extensions
{
    internal static class CandidateSkillExtenstion
    {
        internal static CandidateSkill AsCandidateSkill(this CandidateSkillBaseDto CandidateSkillDto)
        {
            return CandidateSkill.Create(CandidateSkillDto.Name, CandidateSkillDto.Experience, CandidateSkillDto.Level);
        }
        internal static IEnumerable<CandidateSkill> AsCandidateSkill(this IEnumerable<CandidateSkillBaseDto> CandidateSkillDto)
        {
            return CandidateSkillDto.Select(skill => skill.AsCandidateSkill());
        }
        internal static CandidateSkill AsCandidateSkill(this CandidateSkillDto CandidateSkillDto)
        {
            return CandidateSkill.Create(CandidateSkillDto.Id, CandidateSkillDto.Name, CandidateSkillDto.Experience, CandidateSkillDto.Level);
        }
        internal static IEnumerable<CandidateSkill> AsCandidateSkill(this IEnumerable<CandidateSkillDto> CandidateSkillDto)
        {
            return CandidateSkillDto.Select(skill => skill.AsCandidateSkill());
        }
    }
}

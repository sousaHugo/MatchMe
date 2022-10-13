using MatchMe.Candidates.Domain.Entities;

namespace MatchMe.Candidates.Application.Dto.CandidatesExperience.Extensions
{
    internal static class CandidateExperienceExtention
    {
        internal static CandidateExperience AsCandidateExperience(this CandidateExperienceBaseDto CandidateExperienceDto)
        {
            return CandidateExperience.Create(CandidateExperienceDto.Role, CandidateExperienceDto.Description, CandidateExperienceDto.Responsibilities,
                CandidateExperienceDto.Company, CandidateExperienceDto.City, CandidateExperienceDto.Country, CandidateExperienceDto.BeginDate, CandidateExperienceDto.EndDate);
        }
        internal static IEnumerable<CandidateExperience> AsCandidateExperience(this IEnumerable<CandidateExperienceBaseDto> CandidateExperienceDto)
        {
            return CandidateExperienceDto.Select(ex => ex.AsCandidateExperience()).AsEnumerable();
        }

        internal static CandidateExperience AsCandidateExperience(this CandidateExperienceDto CandidateExperienceDto)
        {
            return CandidateExperience.Create(CandidateExperienceDto.Id, CandidateExperienceDto.Role, CandidateExperienceDto.Description, CandidateExperienceDto.Responsibilities,
                CandidateExperienceDto.Company, CandidateExperienceDto.City, CandidateExperienceDto.Country, CandidateExperienceDto.BeginDate, CandidateExperienceDto.EndDate);
        }
        internal static IEnumerable<CandidateExperience> AsCandidateExperience(this IEnumerable<CandidateExperienceDto> CandidateExperienceDto)
        {
            return CandidateExperienceDto.Select(ex => ex.AsCandidateExperience()).AsEnumerable();
        }
    }
}

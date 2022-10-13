using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Application.Dto.CandidatesEducation.Extensions
{
    internal static class CandidateEducationExtension
    {
        internal static CandidateEducation AsCandidateEducation(this CandidateEducationBaseDto CandidateEducationDto)
        {
            return CandidateEducation.Create(CandidateEducationDto.Title, CandidateEducationDto.Description, CandidateEducationDto.BeginDate,
                CandidateEducationDto.EndDate, CandidateEducationDto.Organization, 
                new AddressObject(CandidateEducationDto.Address.Street, CandidateEducationDto.Address.City,
                CandidateEducationDto.Address.State, CandidateEducationDto.Address.PostCode, CandidateEducationDto.Address.Country));
        }
        internal static IEnumerable<CandidateEducation> AsCandidateEducation(this IEnumerable<CandidateEducationBaseDto> CandidateEducationDto)
        {
            return CandidateEducationDto.Select(ex => ex.AsCandidateEducation()).AsEnumerable();
        }

        internal static CandidateEducation AsCandidateEducation(this CandidateEducationDto CandidateEducationDto)
        {
            return CandidateEducation.Create(CandidateEducationDto.Title, CandidateEducationDto.Description, CandidateEducationDto.BeginDate,
                CandidateEducationDto.EndDate, CandidateEducationDto.Organization,
                new AddressObject(CandidateEducationDto.Address.Street, CandidateEducationDto.Address.City,
                CandidateEducationDto.Address.State, CandidateEducationDto.Address.PostCode, CandidateEducationDto.Address.Country));
        }
        internal static IEnumerable<CandidateEducation> AsCandidateEducation(this IEnumerable<CandidateEducationDto> CandidateEducationDto)
        {
            return CandidateEducationDto.Select(ex => ex.AsCandidateEducation()).AsEnumerable();
        }
    }
}

using Mapster;
using MatchMe.Candidates.Domain.Entities;

namespace MatchMe.Candidates.Application.Dto.Candidates.Mappings
{
    public static class CandidateToCandidateDtoMapperConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<Candidate, CandidateGetDto>
                    .NewConfig()
                    .Map(dest => dest.FirstName, src => src.FirstName)
                    .Map(dest => dest.LastName, src => src.LastName)
                    .Map(dest => dest.DateOfBirth, src => src.DateOfBirth.Value)
                    .Map(dest => dest.Nationality, src => src.Nationality)
                    .Map(dest => dest.MobilePhone, src => src.MobilePhone)
                    .Map(dest => dest.Email, src => src.Email.Value)
                    .Map(dest => dest.Gender, src => src.Gender.Value)
                    .Map(dest => dest.MaritalStatus, src => src.MaritalStatus.Value)
                    .Map(dest => dest.Address, src => src.Address == null ? null :
                        new CandidateAddressDto(src.Address.Street, src.Address.City, src.Address.State, src.Address.PostCode, src.Address.Country));
        }
    }
}

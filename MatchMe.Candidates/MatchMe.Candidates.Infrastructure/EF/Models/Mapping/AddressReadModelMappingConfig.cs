using MatchMe.Candidates.Application.Dto.Candidates;

namespace MatchMe.Candidates.Infrastructure.EF.Models.Mapping
{
    public static class AddressReadModelMappingConfig
    {
        public static CandidateAddressDto AsCandidateAddressDto(this AddressReadModel CandidateReadModel)
        {
            return new CandidateAddressDto()
            {
                City = CandidateReadModel.City,
                Country = CandidateReadModel.Country,
                PostCode = CandidateReadModel.PostCode,
                State = CandidateReadModel.State,
                Street = CandidateReadModel.Street
            };
        }
    }
}

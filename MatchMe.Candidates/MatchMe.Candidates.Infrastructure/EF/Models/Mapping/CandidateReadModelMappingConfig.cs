using MatchMe.Candidates.Application.Dto;
using MatchMe.Candidates.Application.Dto.Candidates;

namespace MatchMe.Candidates.Infrastructure.EF.Models.Mapping
{
    public static class CandidateReadModelMappingConfig
    {
        public static CandidateGetDto AsCandidateGetDto(this CandidateReadModel CandidateReadModel)
        {
            return new CandidateGetDto()
            {
                Id = CandidateReadModel.Id,
                Email = CandidateReadModel.Email,
                DateOfBirth = CandidateReadModel.DateOfBirth,
                Address = new CandidateAddressDto(CandidateReadModel.Address),
                CitizenCardNumber = CandidateReadModel.CitizenCardNumber,
                FirstName = CandidateReadModel.FirstName,
                LastName = CandidateReadModel.LastName,
                FiscalNumber = CandidateReadModel.FiscalNumber,
                Gender = CandidateReadModel.Gender,
                MaritalStatus = CandidateReadModel.MaritalStatus,
                MobilePhone = CandidateReadModel.MobilePhone,
                Nationality = CandidateReadModel.Nationality,
                Skills = CandidateReadModel.Skills.Select(a => new CandidateSkillDto() { Id = a.Id, Name = a.Name, Experience = a.Experience, Level = a.Level }).ToList()
            };
        }
    }
}

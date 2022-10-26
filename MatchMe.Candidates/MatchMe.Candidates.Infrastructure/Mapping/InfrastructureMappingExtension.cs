using MatchMe.Candidates.Application.Dto;
using MatchMe.Candidates.Application.Dto.Candidates;
using MatchMe.Candidates.Infrastructure.EF.Models;

namespace MatchMe.Candidates.Infrastructure.Mapping
{
    public static class InfrastructureMappingExtension
    {
        public static CandidateGetDto AsCandidateGetDto(this CandidateReadModel Candidate)
        {
            return new CandidateGetDto()
            {
                Nationality = Candidate.Nationality,
                MobilePhone = Candidate.MobilePhone,
                MaritalStatus = Candidate.MaritalStatus,
                LastName = Candidate.LastName,
                CitizenCardNumber = Candidate.CitizenCardNumber,
                DateOfBirth = Candidate.DateOfBirth,
                Email = Candidate.Email,
                FirstName = Candidate.FirstName,
                FiscalNumber = Candidate.FiscalNumber,
                Gender = Candidate.Gender,
                Id = Candidate.Id,
                Address = Candidate.Address != null ? Candidate.Address.AsCandidateAddressDto() : null,
                Skills = Candidate.Skills.AsCandidateSkillDto().ToList()
            };
        }
        public static CandidateAddressDto AsCandidateAddressDto(this AddressReadModel Address)
        {
            return new CandidateAddressDto()
            {
                City = Address.City,
                Country = Address.Country,
                PostCode = Address.PostCode,
                State = Address.State,
                Street = Address.Street
            };
        }
        public static CandidateSkillDto AsCandidateSkillDto(this CandidateSkillReadModel Skill)
        {
            return new CandidateSkillDto()
            {
                Experience = Skill.Experience,
                Id = Skill.Id,
                Level = Skill.Level,
                Name = Skill.Name
            };
        }
        public static CandidateSkillGetDto AsCandidateSkillGetDto(this CandidateSkillReadModel Skill)
        {
            return new CandidateSkillGetDto()
            {
                Experience = Skill.Experience,
                Id = Skill.Id,
                Level = Skill.Level,
                Name = Skill.Name
            };
        }
        public static IEnumerable<CandidateSkillDto> AsCandidateSkillDto(this IEnumerable<CandidateSkillReadModel> Skill)
        {
            return Skill.Select(a => a.AsCandidateSkillDto());
        }

    }
}

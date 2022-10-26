using MatchMe.Candidates.Application.Dto;
using MatchMe.Candidates.Application.Dto.Candidates;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Application.Mapping
{
    public static partial class ApplicationMappingExtension
    {
        public static CandidateGetDto AsCandidateGetDto(this Candidate Candidate)
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
        public static CandidateAddressDto AsCandidateAddressDto(this AddressObject Address)
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
        public static CandidateSkillDto AsCandidateSkillDto(this CandidateSkill Skill)
        {
            return new CandidateSkillDto()
            {
                Experience = Skill.Experience,
                Id = Skill.Id,
                Level = Skill.Level,
                Name = Skill.Name
            };
        }
        public static IEnumerable<CandidateSkillDto> AsCandidateSkillDto(this IEnumerable<CandidateSkill> Skill)
        {
            return Skill.Select(a => a.AsCandidateSkillDto());
        }
    }
}

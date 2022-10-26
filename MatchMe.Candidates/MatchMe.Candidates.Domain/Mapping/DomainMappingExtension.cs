using MatchMe.Candidates.Domain.Entities;
using MatchMe.Candidates.Domain.Events.Models;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Mapping
{
    public static class DomainMappingExtension
    {
        public static CandidateDEModel AsCandidateDEModel(this Candidate Candidate)
        {
            return new CandidateDEModel()
            {
                Address = Candidate.Address != null ? Candidate.Address.AsAddressDEModel() : null,
                CitizenCardNumber = Candidate.CitizenCardNumber,
                DateOfBirth = Candidate.DateOfBirth,
                Educations = Candidate.Educations.AsCandidateEducationDEModel(),
                Email = Candidate.Email,
                Experiencies = Candidate.Experiences.AsCandidateExperienceDEModel(),
                FirstName = Candidate.FirstName,
                FiscalNumber = Candidate.FiscalNumber,
                Gender = Candidate.Gender,
                Id = Candidate.Id,
                Skills = Candidate.Skills.AsCandidateSkillDEModel(),
                LastName = Candidate.LastName,
                MaritalStatus = Candidate.MaritalStatus,
                MobilePhone = Candidate.MobilePhone,
                Nationality = Candidate.Nationality
            };
        }
        public static AddressDEModel AsAddressDEModel(this AddressObject Address)
        {
            return new AddressDEModel() { City = Address.City, Country = Address.Country, PostCode = Address.PostCode, State = Address.State, Street = Address.Street };
        }
        public static IEnumerable<AddressDEModel> AsAddressDEModel(this IEnumerable<AddressObject> Address)
        {
            return Address.Select(a => a.AsAddressDEModel());
        }
        public static CandidateEducationDEModel AsCandidateEducationDEModel(this CandidateEducation Education)
        {
            return new CandidateEducationDEModel() { Address = Education.Address != null ? Education.Address.AsAddressDEModel() : null, BeginDate = Education.BeginDate,
                Description = Education.Description, EndDate = Education.EndDate, Id = Education.Id , Organization = Education.Organization , Title = Education.Title
            };
        }
        public static IEnumerable<CandidateEducationDEModel> AsCandidateEducationDEModel(this IEnumerable<CandidateEducation> Education)
        {
            return Education.Select(a => a.AsCandidateEducationDEModel());
        }
        public static CandidateExperienceDEModel AsCandidateExperienceDEModel(this CandidateExperience Experience)
        {
            return new CandidateExperienceDEModel()
            {
                BeginDate = Experience.BeginDate,
                EndDate = Experience.EndDate,
                Id = Experience.Id,
                City = Experience.City,
                Company = Experience.Company,
                Country = Experience.Country,
                Description = Experience.Description,
                Responsibilities = Experience.Responsibilities,
                Role = Experience.Role
            };
        }
        public static IEnumerable<CandidateExperienceDEModel> AsCandidateExperienceDEModel(this IEnumerable<CandidateExperience> Experience)
        {
            return Experience.Select(a => a.AsCandidateExperienceDEModel());
        }
        public static CandidateSkillDEModel AsCandidateSkillDEModel(this CandidateSkill Skill)
        {
            return new CandidateSkillDEModel()
            {
               Experience = Skill.Experience,
               Id = Skill.Id,
               Level = Skill.Level,
               Name = Skill.Name
            };
        }
        public static IEnumerable<CandidateSkillDEModel> AsCandidateSkillDEModel(this IEnumerable<CandidateSkill> Experience)
        {
            return Experience.Select(a => a.AsCandidateSkillDEModel());
        }

    }
}

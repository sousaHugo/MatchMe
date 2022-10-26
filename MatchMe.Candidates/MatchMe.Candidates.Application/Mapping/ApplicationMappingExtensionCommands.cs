using MatchMe.Candidates.Application.Commands.Candidates;
using MatchMe.Candidates.Application.Commands.Candidates.Models;
using MatchMe.Candidates.Application.Dto;
using MatchMe.Candidates.Application.Dto.Candidates;
using MatchMe.Candidates.Application.Dto.CandidatesEducation;
using MatchMe.Candidates.Application.Dto.CandidatesExperience;
using MatchMe.Candidates.Application.Dto.CandidatesSkill;
using MatchMe.Candidates.Domain.Entities;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Application.Mapping
{
    public static partial class ApplicationMappingExtension
    {
        public static CreateCandidateCommand AsCreateCandidateCommand(this CandidateCreateDto Dto)
        {
            return new CreateCandidateCommand(Dto.FirstName, Dto.LastName, Dto.FiscalNumber, Dto.CitizenCardNumber,
                Dto.DateOfBirth, new CandidateAddressCommandModel(Dto.Address.Street, Dto.Address.City, Dto.Address.State,
                Dto.Address.PostCode, Dto.Address.Country), Dto.Nationality, Dto.MobilePhone, Dto.Email, Dto.Gender,
                Dto.MaritalStatus, new List<CandidateSkillCommandModel>(), new List<CandidateEducationCommandModel>(),
                new List<CandidateExperienceCommandModel>());
        }
        public static CreateCandidateCommand AsCreateCandidateCommand(this CandidateCreateWithDetailsDto Dto)
        {
            return new CreateCandidateCommand(Dto.FirstName, Dto.LastName, Dto.FiscalNumber, Dto.CitizenCardNumber,
                Dto.DateOfBirth, new CandidateAddressCommandModel(Dto.Address.Street, Dto.Address.City, Dto.Address.State,
                Dto.Address.PostCode, Dto.Address.Country), Dto.Nationality, Dto.MobilePhone, Dto.Email, Dto.Gender,
                Dto.MaritalStatus, Dto.Skills.AsCandidateSkillCommandWriteModel(), Dto.Educations.AsCandidateEducationCommandWriteModel(),
                Dto.Experiences.AsCandidateExperienceCommandWriteModel());
        }
        public static UpdateCandidateCommand AsUpdateCandidateCommand(this CandidateUpdateWithDetailsDto Dto)
        {
            return new UpdateCandidateCommand(Dto.Id, Dto.FirstName, Dto.LastName, Dto.FiscalNumber, Dto.CitizenCardNumber,
                Dto.DateOfBirth, new CandidateAddressCommandModel(Dto.Address.Street, Dto.Address.City, Dto.Address.State,
                Dto.Address.PostCode, Dto.Address.Country), Dto.Nationality, Dto.MobilePhone, Dto.Email, Dto.Gender,
                Dto.MaritalStatus, Dto.Skills.AsCandidateSkillCommandWriteModel(), Dto.Educations.AsCandidateEducationCommandWriteModel(),
                Dto.Experiences.AsCandidateExperienceCommandWriteModel());
        }
        public static CandidateSkillCommandModel AsCandidateSkillCommandWriteModel(this CandidateSkillBaseDto Dto)
        {
            return new CandidateSkillCommandModel(Dto.Name, Dto.Experience, Dto.Level);
        }
        public static CandidateSkillCommandModel AsCandidateSkillCommandWriteModel(this CandidateSkillDto Dto)
        {
            return new CandidateSkillCommandModel(Dto.Id, Dto.Name, Dto.Experience, Dto.Level);
        }
        public static IEnumerable<CandidateSkillCommandModel> AsCandidateSkillCommandWriteModel(this IEnumerable<CandidateSkillBaseDto> Dto)
        {
            return Dto.Select(a => a.AsCandidateSkillCommandWriteModel());
        }
        public static IEnumerable<CandidateSkillCommandModel> AsCandidateSkillCommandWriteModel(this IEnumerable<CandidateSkillDto> Dto)
        {
            return Dto.Select(a => a.AsCandidateSkillCommandWriteModel());
        }
        public static CandidateEducationCommandModel AsCandidateEducationCommandWriteModel(this CandidateEducationBaseDto Dto)
        {
            return new CandidateEducationCommandModel(Dto.Title, Dto.Organization,
                new CandidateAddressCommandModel(Dto.Address.Street, Dto.Address.City, Dto.Address.State, Dto.Address.PostCode,
                Dto.Address.Country), Dto.BeginDate, Dto.EndDate, Dto.Description);
        }
        public static CandidateEducationCommandModel AsCandidateEducationCommandWriteModel(this CandidateEducationDto Dto)
        {
            return new CandidateEducationCommandModel(Dto.Id, Dto.Title, Dto.Organization,
                new CandidateAddressCommandModel(Dto.Address.Street, Dto.Address.City, Dto.Address.State, Dto.Address.PostCode,
                Dto.Address.Country), Dto.BeginDate, Dto.EndDate, Dto.Description);
        }
        public static IEnumerable<CandidateEducationCommandModel> AsCandidateEducationCommandWriteModel(this IEnumerable<CandidateEducationBaseDto> Dto)
        {
            return Dto.Select(a => a.AsCandidateEducationCommandWriteModel());
        }
        public static IEnumerable<CandidateEducationCommandModel> AsCandidateEducationCommandWriteModel(this IEnumerable<CandidateEducationDto> Dto)
        {
            return Dto.Select(a => a.AsCandidateEducationCommandWriteModel());
        }
        public static CandidateExperienceCommandModel AsCandidateExperienceCommandWriteModel(this CandidateExperienceBaseDto Dto)
        {
            return new CandidateExperienceCommandModel(Dto.Role, Dto.Company, Dto.City, Dto.Country, Dto.BeginDate, Dto.EndDate, Dto.Description, Dto.Responsibilities);
        }
        public static CandidateExperienceCommandModel AsCandidateExperienceCommandWriteModel(this CandidateExperienceDto Dto)
        {
            return new CandidateExperienceCommandModel(Dto.Id, Dto.Role, Dto.Company, Dto.City, Dto.Country, Dto.BeginDate, Dto.EndDate, Dto.Description, Dto.Responsibilities);
        }
        public static IEnumerable<CandidateExperienceCommandModel> AsCandidateExperienceCommandWriteModel(this IEnumerable<CandidateExperienceBaseDto> Dto)
        {
            return Dto.Select(a => a.AsCandidateExperienceCommandWriteModel());
        }
        public static IEnumerable<CandidateExperienceCommandModel> AsCandidateExperienceCommandWriteModel(this IEnumerable<CandidateExperienceDto> Dto)
        {
            return Dto.Select(a => a.AsCandidateExperienceCommandWriteModel());
        }
        public static CandidateSkill AsCandidateSkill(this CandidateSkillCommandModel CommandWriteModel)
        {
            if(CommandWriteModel.Id == 0)
                return CandidateSkill.Create(CommandWriteModel.Name, CommandWriteModel.Experience, CommandWriteModel.Level);

            return CandidateSkill.Create(CommandWriteModel.Id, CommandWriteModel.Name, CommandWriteModel.Experience, CommandWriteModel.Level);
        }
        public static IEnumerable<CandidateSkill> AsCandidateSkill(this IEnumerable<CandidateSkillCommandModel> CommandWriteModel)
        {
            return CommandWriteModel.Select(skill => skill.AsCandidateSkill());
        }
        public static CandidateExperience AsCandidateExperience(this CandidateExperienceCommandModel CommandWriteModel)
        {
            if(CommandWriteModel.Id == 0)
                return CandidateExperience.Create(CommandWriteModel.Role, CommandWriteModel.Description, CommandWriteModel.Responsibilities,
                    CommandWriteModel.Company, CommandWriteModel.City, CommandWriteModel.Country, CommandWriteModel.BeginDate, CommandWriteModel.EndDate);

            return CandidateExperience.Create(CommandWriteModel.Id, CommandWriteModel.Role, CommandWriteModel.Description, CommandWriteModel.Responsibilities,
                   CommandWriteModel.Company, CommandWriteModel.City, CommandWriteModel.Country, CommandWriteModel.BeginDate, CommandWriteModel.EndDate);
        }
        public static IEnumerable<CandidateExperience> AsCandidateExperience(this IEnumerable<CandidateExperienceCommandModel> CommandWriteModel)
        {
            return CommandWriteModel.Select(ex => ex.AsCandidateExperience()).AsEnumerable();
        }
        public static CandidateEducation AsCandidateEducation(this CandidateEducationCommandModel CommandWriteModel)
        {
            if(CommandWriteModel.Id == 0)
                return CandidateEducation.Create(CommandWriteModel.Title, CommandWriteModel.Description, CommandWriteModel.BeginDate,
                    CommandWriteModel.EndDate, CommandWriteModel.Organization,
                    new AddressObject(CommandWriteModel.Address.Street, CommandWriteModel.Address.City,
                    CommandWriteModel.Address.State, CommandWriteModel.Address.PostCode, CommandWriteModel.Address.Country));

            return CandidateEducation.Create(CommandWriteModel.Id, CommandWriteModel.Title, CommandWriteModel.Description, CommandWriteModel.BeginDate,
                    CommandWriteModel.EndDate, CommandWriteModel.Organization,
                    new AddressObject(CommandWriteModel.Address.Street, CommandWriteModel.Address.City,
                    CommandWriteModel.Address.State, CommandWriteModel.Address.PostCode, CommandWriteModel.Address.Country));
        }
        public static IEnumerable<CandidateEducation> AsCandidateEducation(this IEnumerable<CandidateEducationCommandModel> CommandWriteModel)
        {
            return CommandWriteModel.Select(ex => ex.AsCandidateEducation()).AsEnumerable();
        }

    }
}

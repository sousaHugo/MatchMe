using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Candidates.Domain.Events.Models
{
    public class CandidateDEModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AddressDEModel Address { get; set; }
        public string FiscalNumber { get; set; }
        public string CitizenCardNumber { get; set; }
        public string Nationality { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public GenderEnum Gender { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public IEnumerable<CandidateSkillDEModel> Skills { get; set; }
        public IEnumerable<CandidateExperienceDEModel> Experiencies { get; set; }
        public IEnumerable<CandidateEducationDEModel> Educations { get; set; }
    }
}

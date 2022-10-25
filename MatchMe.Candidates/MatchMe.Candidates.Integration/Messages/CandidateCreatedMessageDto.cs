using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Integration;

namespace MatchMe.Candidates.Integration.Messages
{
    public class CandidateCreatedMessageDto : BaseMessageDto
    {
        public CandidateCreatedMessageDto(long Id, string FirstName, string LastName, DateTime DateOfBirth,
            CandidateCreatedAddressMessageDto Address, GenderEnum Gender, MaritalStatusEnum MaritalStatus,
            string Nationality, string MobilePhone, string Email, string FiscalNumber, string CitizenCardNumber,
            IEnumerable<CandidateCreatedSkillMessageDto> Skills)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;   
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.Gender = Gender;
            this.MaritalStatus = MaritalStatus;
            this.Nationality = Nationality;
            this.MobilePhone = MobilePhone;
            this.Email = Email;
            this.FiscalNumber = FiscalNumber;
            this.CitizenCardNumber = CitizenCardNumber;
            this.Skills = Skills;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CandidateCreatedAddressMessageDto Address { get; set; }
        public string FiscalNumber { get; set; }
        public string CitizenCardNumber { get; set; }
        public string Nationality { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public GenderEnum Gender { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public IEnumerable<CandidateCreatedSkillMessageDto> Skills { get; set; }
    }
}

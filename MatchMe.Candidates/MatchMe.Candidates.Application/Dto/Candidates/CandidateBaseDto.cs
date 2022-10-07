using MatchMe.Common.Shared.Constants.Enums;

namespace MatchMe.Candidates.Application.Dto.Candidates
{
    public abstract class CandidateBaseDto
    {
        public CandidateBaseDto()
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FiscalNumber { get; set; }
        public string CitizenCardNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CandidateAddressDto Address { get; set; }
        public string Nationality { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public GenderEnum Gender { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
    }
}

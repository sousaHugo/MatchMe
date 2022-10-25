using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Integration;
using MatchMe.Common.Shared.MongoDb;

namespace MatchMe.Match.Integration.Messages
{
    public class CandidateCreatedMessageDto : BaseMessageDto, IMongoEntity
    {
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
        public ICollection<CandidateCreatedSkillMessageDto> Skills { get; set; }
    }
}

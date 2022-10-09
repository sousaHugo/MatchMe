using MatchMe.Common.Shared.Constants.Enums;
using System.Collections.ObjectModel;

namespace MatchMe.Candidates.Infrastructure.EF.Models
{
    public class CandidateReadModel : BaseModel
    {
        public CandidateReadModel()
        {
            Skills = new Collection<CandidateSkillReadModel>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AddressReadModel Address { get; set; }
        public string FiscalNumber { get; set; }
        public string CitizenCardNumber { get; set; }
        public string Nationality { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public GenderEnum Gender { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public ICollection<CandidateSkillReadModel> Skills { get; set; }
        public int Version { get; set; }
    }
}

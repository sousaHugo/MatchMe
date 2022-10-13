using MatchMe.Common.Shared.Constants.Enums;
using System.Collections.ObjectModel;

namespace MatchMe.Candidates.Infrastructure.EF.Models
{
    public class CandidateReadModel : BaseModel
    {
        public CandidateReadModel()
        {
            Skills = new Collection<CandidateSkillReadModel>();
            Experiencies = new Collection<CandidateExperienceReadModel>();
            Educations = new Collection<CandidateEducationReadModel>();
        }
        public string FirstName { get;  }
        public string LastName { get;  }
        public DateTime DateOfBirth { get;  }
        public AddressReadModel Address { get;  }
        public string FiscalNumber { get;  }
        public string CitizenCardNumber { get;  }
        public string Nationality { get;  }
        public string MobilePhone { get;  }
        public string Email { get;  }
        public GenderEnum Gender { get;  }
        public MaritalStatusEnum MaritalStatus { get;  }
        public ICollection<CandidateSkillReadModel> Skills { get; }
        public ICollection<CandidateExperienceReadModel> Experiencies { get; }
        public ICollection<CandidateEducationReadModel> Educations { get; }
    }
}

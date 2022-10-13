using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Entities
{
    public partial class CandidateExperience : BaseEntity<Identity>
    {
        private string _role;
        private string _description;
        private string _responsibilities;
        private string _company;
        private string _city;
        private string _country;
        private DateTime _beginDate;
        private DateTime? _endDate;

        public string Role => _role;
        public string Description => _description;
        public string Responsibilities => _responsibilities;
        public string Company => _company;
        public string City => _city;
        public string Country => _country;
        public DateTime BeginDate => _beginDate;
        public DateTime? EndDate => _endDate;

        private CandidateExperience() { }
        private CandidateExperience(long Id, string Role, string Description, string Responsibilities, string Company, string City, string Country,
            DateTime BeginDate, DateTime? EndDate) 
        {
            this.Id = Id;
            _role = Role;
            _description = Description;
            _responsibilities = Responsibilities;
            _company = Company;
            _city = City;
            _country = Country;
            _beginDate = BeginDate;
            _endDate = EndDate;
        }
    }
}

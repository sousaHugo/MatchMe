using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Entities
{
    public partial class CandidateEducation : BaseEntity<Identity>
    {
        private string _title;
        private string _description;
        private DateTime _beginDate;
        private DateTime? _endDate;
        private string _organization;
        private AddressObject _address;

        public string Title => _title;
        public string Description => _description;
        public DateTime BeginDate => _beginDate;
        public DateTime? EndDate => _endDate;
        public string Organization => _organization;
        public AddressObject Address => _address;
        
        private CandidateEducation() { }
        public CandidateEducation(long Id, string Title, string Description, DateTime BeginDate, DateTime? EndDate, string Organization, AddressObject Address)
        {
            this.Id = Id;
            _title = Title;
            _description = Description;
            _beginDate = BeginDate;
            _endDate = EndDate;
            _organization = Organization;
            _address = Address;
        }
    }
}

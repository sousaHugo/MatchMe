using IdGen;
using MatchMe.Candidates.Domain.Entities.Extensions;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Entities
{
    public partial class CandidateEducation 
    {
        public static CandidateEducation Create(long Id, string Title, string Description, DateTime BeginDate, DateTime? EndDate, string Organization, AddressObject Address)
        {
            var education = new CandidateEducation(Id, Title, Description, BeginDate, EndDate, Organization, Address);
            education.Validate();

            return education;
        }
        public static CandidateEducation Create(string Title, string Description, DateTime BeginDate, DateTime? EndDate, string Organization, AddressObject Address)
            => Create(new IdGenerator(0).CreateId(), Title, Description, BeginDate, EndDate, Organization, Address);

        public void Update(string Title, string Description, DateTime BeginDate, DateTime? EndDate, string Organization, AddressObject Address)
        {
            _title = Title;
            _description = Description;
            _beginDate = BeginDate;
            _endDate = EndDate;
            _organization = Organization;
            _address = Address;

            this.Validate();
        }
    }
}

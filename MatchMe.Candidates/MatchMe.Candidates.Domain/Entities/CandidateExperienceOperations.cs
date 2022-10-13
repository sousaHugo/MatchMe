using IdGen;
using MatchMe.Candidates.Domain.Entities.Extensions;

namespace MatchMe.Candidates.Domain.Entities
{
    public partial class CandidateExperience
    {
        public static CandidateExperience Create(long Id, string Role, string Description, string Responsibilities, string Company, string City, string Country, DateTime BeginDate,
            DateTime? EndDate)
        {
            var experience = new CandidateExperience(Id, Role, Description, Responsibilities, Company, City, Country, BeginDate, EndDate);
            experience.Validate();

            return experience;
        }
        public static CandidateExperience Create(string Role, string Description, string Responsibilities, string Company, string City, string Country,DateTime BeginDate,
            DateTime? EndDate)
            => Create(new IdGenerator(0).CreateId(), Role, Description, Responsibilities, Company, City, Country, BeginDate,EndDate);

        public void Update(string Role, string Description, string Responsibilities, string Company, string City, string Country,
            DateTime BeginDate, DateTime? EndDate)
        {
            _role = Role;
            _description = Description;
            _responsibilities = Responsibilities;
            _company = Company;
            _city = City;
            _country = Country;
            _beginDate = BeginDate;
            _endDate = EndDate;

            this.Validate();
        }
    
    }
}

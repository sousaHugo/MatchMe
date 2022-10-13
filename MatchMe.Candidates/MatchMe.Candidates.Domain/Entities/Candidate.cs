using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Entities
{
    public partial class Candidate : AggregateRoot<Identity>
    {
        private string _firstName;
        private string _lastName;
        private DateOfBirthObject _dateOfBirth;
        private AddressObject _address;
        private string _nationality;
        private string _mobilePhone;
        private EmailObject _email;
        private GenderObject _gender;
        private MaritalStatusObject _maritalStatus;
        private FiscalNumberObject _fiscalNumber;
        private CitizenCardNumberObject _citizenCardNumber;
        private readonly LinkedList<CandidateSkill> _skills = new();
        private readonly LinkedList<CandidateExperience> _experiences = new();
        private readonly LinkedList<CandidateEducation> _educations = new();
        
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public DateOfBirthObject DateOfBirth => _dateOfBirth;
        public AddressObject Address => _address;
        public string Nationality => _nationality;
        public string MobilePhone => _mobilePhone;
        public EmailObject Email => _email;
        public GenderObject Gender => _gender;
        public MaritalStatusObject MaritalStatus => _maritalStatus;
        public FiscalNumberObject FiscalNumber => _fiscalNumber;
        public CitizenCardNumberObject CitizenCardNumber => _citizenCardNumber;
        public LinkedList<CandidateSkill> Skills => _skills;
        public LinkedList<CandidateExperience> Experiences => _experiences;
        public LinkedList<CandidateEducation> Educations => _educations;

        private Candidate() { }
        public Candidate(long Id,string FirstName, string LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, string Nationality,
            string MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber)
        {
            this.Id = Id;
            _firstName = FirstName;
            _lastName = LastName;
            _dateOfBirth = DateOfBirth;
            _address = Address;
            _gender = Gender;
            _maritalStatus = MaritalStatus;
            _email = Email;
            _nationality = Nationality;
            _mobilePhone = MobilePhone;
            _fiscalNumber = FiscalNumber;
            _citizenCardNumber = CitizenCardNumber;
        }
    }
}

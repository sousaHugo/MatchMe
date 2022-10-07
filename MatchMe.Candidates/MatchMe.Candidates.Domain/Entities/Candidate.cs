using IdGen;
using MatchMe.Candidates.Domain.Entities.Extensions;
using MatchMe.Candidates.Domain.Events;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Candidates.Domain.Entities
{
    public class Candidate : AggregateRoot<Identity>
    {
        private TextObject _firstName;
        private TextObject _lastName;
        private DateOfBirthObject _dateOfBirth;
        private AddressObject _address;
        private TextObject _nationality;
        private TextObject _mobilePhone;
        private EmailObject _email;
        private GenderObject _gender;
        private MaritalStatusObject _maritalStatus;
        private FiscalNumberObject _fiscalNumber;
        private CitizenCardNumberObject _citizenCardNumber;
        private LinkedList<CandidateSkill> _skills = new();

        public TextObject FirstName => _firstName;
        public TextObject LastName => _lastName;
        public DateOfBirthObject DateOfBirth => _dateOfBirth;
        public AddressObject Address => _address;
        public TextObject Nationality => _nationality;
        public TextObject MobilePhone => _mobilePhone;
        public EmailObject Email => _email;
        public GenderObject Gender => _gender;
        public MaritalStatusObject MaritalStatus => _maritalStatus;
        public FiscalNumberObject FiscalNumber => _fiscalNumber;
        public CitizenCardNumberObject CitizenCardNumber => _citizenCardNumber;
        public LinkedList<CandidateSkill> Skills => _skills;
        
        private Candidate() { }
        public Candidate(TextObject FirstName, TextObject LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, TextObject Nationality,
            TextObject MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber)
        {
            Id = new IdGenerator(0).CreateId();
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

            this.Validate();
            AddEvent(new CandidateCreatedEvent(this));
        }
  
        
        public void Update(TextObject FirstName, TextObject LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, TextObject Nationality,
            TextObject MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber, IEnumerable<CandidateSkill> Skills)
        {
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


            AddOrRemoveSkills(Skills);
            this.Validate();
            AddEvent(new CandidateUpdatedEvent(this));
        }
        
        
        private void AddOrRemoveSkills(IEnumerable<CandidateSkill> Skills)
        {
            this.Skills.ToList().ForEach(skill =>
            {
                if (!Skills.Any(a => a.Id == skill.Id))
                    RemoveSkill(skill);
            });
            AddOrUpdateSkills(Skills);
        }
        private void AddOrUpdateSkills(IEnumerable<CandidateSkill> Skills)
        {
            this.Skills.ToList().ForEach(skill =>
            {
                var existingSkill = _skills.FirstOrDefault(a => a.Id == skill.Id || a.Name == skill.Name);
                if (existingSkill != null)
                    UpdateSkill(skill);
                else
                    AddSkill(skill);

            });
        }
        public void AddSkill(CandidateSkill Skill)
        {
            var alreadyExists = _skills.FirstOrDefault(a => a.Id == Skill.Id || a.Name == Skill.Name);
            if (alreadyExists != null)
                throw new DomainEntityValidationErrorException($"Skill {Skill.Name} already belongs to the Candidate.");
          
            _skills.AddLast(Skill);
            AddEvent(new CandidateSkillAddedEvent(Skill));
        }
        public void UpdateSkill(CandidateSkill Skill)
        {
            var skill = _skills.FirstOrDefault(a => a.Id == Skill.Id || a.Name == Skill.Name);

            if (skill == null)
                throw new DomainEntityValidationErrorException($"Skill {Skill.Name} doesn't belong to the Candidate.");

            skill.Update(Skill.Name, Skill.Experience, Skill.Level);
            AddEvent(new CandidateSkillUpdatedEvent(Skill));
        }
        public void RemoveSkill(CandidateSkill Skill)
        {
            var doesntExists = !_skills.Any(a => a.Name == Skill.Name);
            if (doesntExists)
                throw new DomainEntityValidationErrorException($"Candidate: {_firstName} {_lastName} doesn't have {Skill.Name} skill defined.");

            _skills.Remove(Skill);
            AddEvent(new CandidateSkillRemoveEvent(Skill));
        }
        public void RemoveSkill(long Id)
        {
            var skill = _skills.FirstOrDefault(a => a.Id == Id);
            if (skill == null)
                throw new DomainEntityValidationErrorException($"Candidate: {_firstName} {_lastName} doesn't have this skill defined.");

            RemoveSkill(skill);
        }
        public void AddSkills(IEnumerable<CandidateSkill> Skills)
        {
            foreach (var item in Skills)
            {
                AddSkill(item);
            }
        }
        public void RemoveSkills(IEnumerable<CandidateSkill> Skills)
        {
            foreach (var item in Skills)
            {
                RemoveSkill(item);
            }
        }
    }
}

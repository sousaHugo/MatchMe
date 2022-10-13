using IdGen;
using MatchMe.Candidates.Domain.Entities.Extensions;
using MatchMe.Candidates.Domain.Events;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Candidates.Domain.Entities
{
    public partial class Candidate 
    {       
        public static Candidate Create(string FirstName, string LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, string Nationality,
          string MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber)
        {
            Candidate candidate = new(new IdGenerator(0).CreateId(), FirstName, LastName, DateOfBirth, Address, Gender, MaritalStatus, Nationality, MobilePhone, Email, FiscalNumber, CitizenCardNumber);
            
            candidate.Validate();
            candidate.AddEvent(new CandidateDomainEvent(candidate, CandidateDomainEventTypes.CandidateCreatedDomainEvent));
            
            return candidate;
        }

        public static Candidate Create(string FirstName, string LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, string Nationality,
           string MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber, IEnumerable<CandidateSkill> Skills,
            IEnumerable<CandidateExperience> Experiences, IEnumerable<CandidateEducation> Educations)
        {
            Candidate candidate = new(new IdGenerator(0).CreateId(),FirstName, LastName, DateOfBirth, Address, Gender, MaritalStatus, Nationality, MobilePhone, Email, FiscalNumber, CitizenCardNumber);
            candidate.AddSkills(Skills ?? new List<CandidateSkill>());
            candidate.AddExperiences(Experiences ?? new List<CandidateExperience>());
            candidate.AddEducations(Educations ?? new List<CandidateEducation>());

            candidate.Validate();
            candidate.AddEvent(new CandidateDomainEvent(candidate, CandidateDomainEventTypes.CandidateCreatedDomainEvent));

            return candidate;
        }

        public void Update(string FirstName, string LastName, DateOfBirthObject DateOfBirth, AddressObject Address, GenderObject Gender, MaritalStatusObject MaritalStatus, string Nationality,
            string MobilePhone, EmailObject Email, FiscalNumberObject FiscalNumber, CitizenCardNumberObject CitizenCardNumber, IEnumerable<CandidateSkill> Skills,
            IEnumerable<CandidateExperience> Experiences, IEnumerable<CandidateEducation> Educations)
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
            AddOrRemoveExperiences(Experiences);
            AddOrRemoveEducations(Educations);

            this.Validate();
            
            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateUpdatedDomainEvent));
        }


        #region Candidate_Skills

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
            Skills.ToList().ForEach(skill =>
            {
                var existingSkill = _skills.FirstOrDefault(a => a.Id == skill.Id || a.Name == skill.Name);
                if (existingSkill != null)
                    UpdateSkill(skill);
                else
                    AddSkill(skill);

            });
        }
        public void AddSkills(IEnumerable<CandidateSkill> Skills)
        {
            foreach (var item in Skills)
            {
                AddSkill(item);
            }
        }
        public void AddSkill(CandidateSkill Skill)
        {
            var alreadyExists = _skills.FirstOrDefault(a => a.Id == Skill.Id || a.Name == Skill.Name);
            if (alreadyExists != null)
                throw new DomainEntityValidationErrorException($"Skill {Skill.Name} already belongs to the Candidate.");

            _skills.AddLast(Skill);
            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateAddSkillDomainEvent));
        }
        public void UpdateSkill(CandidateSkill Skill)
        {
            var skill = _skills.FirstOrDefault(a => a.Id == Skill.Id || a.Name == Skill.Name);

            if (skill == null)
                throw new DomainEntityValidationErrorException($"Skill {Skill.Name} doesn't belong to the Candidate.");

            skill.Update(Skill.Name, Skill.Experience, Skill.Level);
            
            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateUpdatedDomainEvent));
        }
        public void RemoveSkills(IEnumerable<CandidateSkill> Skills)
        {
            foreach (var item in Skills)
            {
                RemoveSkill(item);
            }
        }
        public void RemoveSkill(CandidateSkill Skill)
        {
            var doesntExists = !_skills.Any(a => a.Name == Skill.Name);
            if (doesntExists)
                throw new DomainEntityValidationErrorException($"Candidate: {_firstName} {_lastName} doesn't have {Skill.Name} skill defined.");

            _skills.Remove(Skill);
            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateRemoveSkillDomainEvent));
        }
        public void RemoveSkill(long Id)
        {
            var skill = _skills.FirstOrDefault(a => a.Id == Id);
            if (skill == null)
                throw new DomainEntityValidationErrorException($"Candidate: {_firstName} {_lastName} doesn't have this skill defined.");

            RemoveSkill(skill);
        }
        public void CleanSkills()
            => _skills.Clear();

        #endregion

        #region Candidate_Experience

        private void AddOrRemoveExperiences(IEnumerable<CandidateExperience> Experiences)
        {
            this.Experiences.ToList().ForEach(exp =>
            {
                if (!Skills.Any(a => a.Id == exp.Id))
                    RemoveExperience(exp);
            });
            AddOrUpdateExperiences(Experiences);
        }
        private void AddOrUpdateExperiences(IEnumerable<CandidateExperience> Experiences)
        {
            Experiences.ToList().ForEach(exp =>
            {
                var existingExp = _skills.FirstOrDefault(a => a.Id == exp.Id || a.Name == exp.Role);
                if (existingExp != null)
                    UpdateExperience(exp);
                else
                    AddExperience(exp);

            });
        }
        public void AddExperiences(IEnumerable<CandidateExperience> Experiences)
        {
            foreach (var item in Experiences)
            {
                AddExperience(item);
            }
        }
        public void AddExperience(CandidateExperience Experience)
        {
            var alreadyExists = _experiences.FirstOrDefault(a => a.Id == Experience.Id || a.Role == Experience.Role);
            if (alreadyExists != null)
                throw new DomainEntityValidationErrorException($"Experience {Experience.Role} already belongs to the Candidate.");

            Experience.Validate();

            _experiences.AddLast(Experience);
            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateAddExperienceDomainEvent));
        }
        public void UpdateExperience(CandidateExperience Experience)
        {
            var experience = _experiences.FirstOrDefault(a => a.Id == Experience.Id || a.Role == Experience.Role);

            if (experience == null)
                throw new DomainEntityValidationErrorException($"Experience {Experience.Role} doesn't belong to the Candidate.");

            experience.Update(Experience.Role, Experience.Description, Experience.Responsibilities, Experience.Company, Experience.City,
                Experience.Country, Experience.BeginDate, Experience.EndDate);

            experience.Validate();

            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateUpdatedDomainEvent));
        }
        public void RemoveExperiences(IEnumerable<CandidateExperience> Experiences)
        {
            foreach (var item in Experiences)
            {
                RemoveExperience(item);
            }
        }
        public void RemoveExperience(CandidateExperience Experience)
        {
            var doesntExists = !_experiences.Any(a => a.Role == Experience.Role);
            if (doesntExists)
                throw new DomainEntityValidationErrorException($"Candidate: {_firstName} {_lastName} doesn't have {Experience.Role} experience defined.");

            _experiences.Remove(Experience);
            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateRemoveExperienceDomainEvent));
        }
        public void RemoveExperience(long Id)
        {
            var experience = _experiences.FirstOrDefault(a => a.Id == Id);
            if (experience == null)
                throw new DomainEntityValidationErrorException($"Candidate: {_firstName} {_lastName} doesn't have this experience defined.");

            RemoveExperience(experience);
        }
        public void CleanExperiences()
            => _experiences.Clear();

        #endregion

        #region Candidate_Education

        private void AddOrRemoveEducations(IEnumerable<CandidateEducation> Educations)
        {
            this.Educations.ToList().ForEach(exp =>
            {
                if (!Educations.Any(a => a.Id == exp.Id))
                    RemoveEducation(exp);
            });
            AddOrUpdateEducations(Educations);
        }
        private void AddOrUpdateEducations(IEnumerable<CandidateEducation> Educations)
        {
            Educations.ToList().ForEach(edu =>
            {
                var existingEdu = _educations.FirstOrDefault(a => a.Id == edu.Id || a.Title == edu.Title);
                if (existingEdu != null)
                    UpdateEducation(edu);
                else
                    AddEducation(edu);

            });
        }
        public void AddEducations(IEnumerable<CandidateEducation> Educations)
        {
            foreach (var item in Educations)
            {
                AddEducation(item);
            }
        }
        public void AddEducation(CandidateEducation Education)
        {
            var alreadyExists = _educations.FirstOrDefault(a => a.Id == Education.Id || a.Title == Education.Title);
            if (alreadyExists != null)
                throw new DomainEntityValidationErrorException($"Education {Education.Title} already belongs to the Candidate.");

            Education.Validate();

            _educations.AddLast(Education);
            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateAddEducationDomainEvent));
        }
        public void UpdateEducation(CandidateEducation Education)
        {
            var education = _educations.FirstOrDefault(a => a.Id == Education.Id || a.Title == Education.Title);

            if (education == null)
                throw new DomainEntityValidationErrorException($"Education {Education.Title} doesn't belong to the Candidate.");

            education.Update(education.Title, education.Description, education.BeginDate, education.EndDate, education.Organization, education.Address);

            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateUpdateEducationDomainEvent));
        }
        public void RemoveEducations(IEnumerable<CandidateEducation> Educations)
        {
            foreach (var item in Educations)
            {
                RemoveEducation(item);
            }
        }
        public void RemoveEducation(CandidateEducation Education)
        {
            var doesntExists = !_educations.Any(a => a.Title == Education.Title);
            if (doesntExists)
                throw new DomainEntityValidationErrorException($"Candidate: {_firstName} {_lastName} doesn't have {Education.Title} education defined.");

            _educations.Remove(Education);
            AddEvent(new CandidateDomainEvent(this, CandidateDomainEventTypes.CandidateRemoveExperienceDomainEvent));
        }
        public void RemoveEducation(long Id)
        {
            var education = _educations.FirstOrDefault(a => a.Id == Id);
            if (education == null)
                throw new DomainEntityValidationErrorException($"Candidate: {_firstName} {_lastName} doesn't have this education defined.");

            RemoveEducation(education);
        }
        public void CleanEducations()
            => _educations.Clear();

        #endregion
    }
}

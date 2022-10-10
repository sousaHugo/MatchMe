using IdGen;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Opportunities.Domain.Entities.Extensions;
using MatchMe.Opportunities.Domain.Entities.ValueObjects;
using MatchMe.Opportunities.Domain.Events;

namespace MatchMe.Opportunities.Domain.Entities
{
    public class Opportunity : AggregateRoot<Identity>
    {
        private string _title;
        private string _reference;
        private string _description;
        private string _clientId;
        private string _responsible;
        private string _location;
        private OpportunityStatusObject _status;
        private DateTime _beginDate;
        private DateTime _endDate;
        private decimal? _minSalaryYear;
        private decimal? _maxSalaryYear;
        private int? _minExperienceMonth;
        private int? _maxExperienceMonth;
        private readonly LinkedList<OpportunitySkill> _skills = new();

        public string Title => _title;
        public string Reference => _reference;
        public string Description => _description;
        public string ClientId => _clientId;
        public string Responsible => _responsible;
        public string Location => _location;
        public OpportunityStatusObject Status => _status;
        public DateTime BeginDate => _beginDate;
        public DateTime EndDate => _endDate;
        public decimal? MinSalaryYear => _minSalaryYear;
        public decimal? MaxSalaryYear => _maxSalaryYear;
        public int? MinExperienceMonth => _minExperienceMonth;
        public int? MaxExperienceMonth => _maxExperienceMonth;
        public LinkedList<OpportunitySkill> Skills => _skills;

        private Opportunity() { }

        public Opportunity(string Title, string Reference, string Description, string ClientId, string Responsible, string Location, OpportunityStatusObject Status, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth)
        {
            Id = new IdGenerator(0).CreateId();
            _title = Title;
            _reference = Reference;
            _description = Description;
            _clientId = ClientId;
            _responsible = Responsible;
            _location = Location;
            _status = Status;
            _beginDate = BeginDate;
            _endDate = EndDate;
            _minSalaryYear = MinSalaryYear;
            _maxSalaryYear = MaxSalaryYear;
            _minExperienceMonth = MinExperienceMonth;
            _maxExperienceMonth = MaxExperienceMonth;

            this.Validate();
            AddEvent(new OpportunityCreateEvent(this));
        }

        public void Update(string Title, string Description, string ClientId, string Responsible, string Location, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth, IEnumerable<OpportunitySkill> Skills)
        {
            _title = Title;
            _description = Description;
            _clientId = ClientId;
            _responsible = Responsible;
            _location = Location;
            _beginDate = BeginDate;
            _endDate = EndDate;
            _minSalaryYear = MinSalaryYear;
            _maxSalaryYear = MaxSalaryYear;
            _minExperienceMonth = MinExperienceMonth;
            _maxExperienceMonth = MaxExperienceMonth;

            UpdateSkills(Skills);
            this.Validate();
            AddEvent(new OpportunityUpdateEvent(this));
        }
        private void UpdateSkills(IEnumerable<OpportunitySkill> Skills)
        {
            _skills.ToList().ForEach(skill =>
            {
                if (!Skills.Any(a => a.Id == skill.Id))
                    RemoveSkill(skill);
            });
            AddOrUpdateSkills(Skills);
        }
        private void AddOrUpdateSkills(IEnumerable<OpportunitySkill> Skills)
        {
            Skills.ToList().ForEach(skill =>
            {
                AddOrUpdateSkill(skill);
            });
        }
        private void AddOrUpdateSkill(OpportunitySkill Skill)
        {
            var existingSkill = _skills.FirstOrDefault(a => a.Id == Skill.Id);

            if (existingSkill is null && _skills.Any(a => a.Name == Skill.Name))
                throw new DomainEntityValidationErrorException($"Skill {Skill.Name} already belongs to the Opportunity.");
            else if (existingSkill is not null)
                UpdateSkill(Skill);
            else
                AddSkill(Skill);

        }
        public void AddSkill(OpportunitySkill Skill)
        {
            var alreadyExists = _skills.Any(a => a.Name == Skill.Name);
            if (alreadyExists)
                throw new DomainEntityAlreadyExistsException(nameof(OpportunitySkill), "Skill", Skill.Name);

            _skills.AddLast(Skill);
            AddEvent(new OpportunitySkillAddedEvent(Skill, this.Title));
        }
        public void AddSkills(IEnumerable<OpportunitySkill> Skills)
        {
            foreach(var item in Skills)
            {
                AddSkill(item);
            }
        }
        public void UpdateSkill(OpportunitySkill Skill)
        {
            var skill = GetSkill(Skill);

            var newSkill = skill.Update(Skill.Name, Skill.MinExperience, Skill.MaxExperience, Skill.Level, Skill.Mandatory);

            _skills.Find(skill).Value = newSkill;
            AddEvent(new OpportunitySkillUpdateEvent(skill, this.Title));
        }
        public void RemoveSkill(OpportunitySkill Skill)
        {
            var skill = GetSkill(Skill);

            _skills.Remove(Skill);

            AddEvent(new OpportunitySkillRemoveEvent(skill, this.Title));
        }
        private OpportunitySkill GetSkill(OpportunitySkill Skill)
        {
            var skill = _skills.SingleOrDefault(a => a.Name == Skill.Name || (Skill.Id != 0 && a.Id == Skill.Id));

            if(skill is null)
                throw new DomainEntityValidationErrorException($"Skill {Skill.Name} doesn't belong to the Candidate.");

            return skill;
        }
    }
}

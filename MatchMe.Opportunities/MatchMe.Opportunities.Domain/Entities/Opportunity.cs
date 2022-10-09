using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Opportunities.Domain.Entities.ValueObjects;
using MatchMe.Opportunities.Domain.Events;
using MatchMe.Opportunities.Domain.Exceptions;

namespace MatchMe.Opportunities.Domain.Entities
{
    public class Opportunity : AggregateRoot<Identity>
    {
        private string _title;
        private string _reference;
        private string _descritption;
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
        public string Descritption => _descritption;
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

        public Opportunity(string Title, string Reference, string Descritption, string ClientId, string Responsible, string Location, OpportunityStatusObject Status, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth)
        {
            _title = Title;
            _reference = Reference;
            _descritption = Descritption;
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
        }

        public void AddSkill(OpportunitySkill Skill)
        {
            var alreadyExists = _skills.Any(a => a.Name == Skill.Name);
            if (alreadyExists)
                throw new OpportunitySkillAlreadyExistsException(_title, Skill.Name);

            _skills.AddLast(Skill);
            AddEvent(new OpportunitySkillAddedEvent(this, Skill));
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

            var newSkill = skill.Update(Skill.Name, skill.MinExperience, skill.MaxExperience, skill.Level, skill.Mandatory);

            _skills.Find(skill).Value = newSkill;
            AddEvent(new OpportunitySkillUpdateEvent(this, skill));
        }
        public void RemoveSkill(OpportunitySkill Skill)
        {
            var skill = GetSkill(Skill);

            _skills.Remove(Skill);

            AddEvent(new OpportunitySkillRemoveEvent(this, skill));
        }
        public void MandatorySkill(string SkillName)
        {
            var skill = GetSkill(SkillName);
            var newSkill = skill.IsMandatory(true);
            
            _skills.Find(skill).Value = newSkill;
            AddEvent(new OpportunitySkillUpdateEvent(this, skill));
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

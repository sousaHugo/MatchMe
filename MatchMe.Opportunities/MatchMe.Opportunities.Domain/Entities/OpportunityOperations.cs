using MatchMe.Common.Shared.Constants.Enums;
using MatchMe.Common.Shared.Exceptions;
using MatchMe.Opportunities.Domain.Entities.Extensions;
using MatchMe.Opportunities.Domain.Entities.Helpers;
using MatchMe.Opportunities.Domain.Events;

namespace MatchMe.Opportunities.Domain.Entities
{
    public partial class Opportunity
    {
        public static Opportunity Create(string Title, string Description, string ClientId, string Responsible, string Location, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth)
            => new Opportunity(Title, OpportunityHelper.GenerateReference(), Description, ClientId, Responsible, Location, OpportunityStatusEnum.Registered, BeginDate, EndDate, MinSalaryYear,
                MaxSalaryYear, MinExperienceMonth, MaxExperienceMonth);

        public static Opportunity Create(string Title, string Description, string ClientId, string Responsible, string Location, DateTime BeginDate, DateTime EndDate,
            decimal? MinSalaryYear, decimal? MaxSalaryYear, int? MinExperienceMonth, int? MaxExperienceMonth,IEnumerable<OpportunitySkill> Skills)
        {
            var opportunity = new Opportunity(Title, OpportunityHelper.GenerateReference(), Description, ClientId, Responsible, Location, OpportunityStatusEnum.Registered, BeginDate, EndDate, MinSalaryYear,
                MaxSalaryYear, MinExperienceMonth, MaxExperienceMonth);

            opportunity.AddSkills(Skills);

            return opportunity;
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
            AddEvent(new OpportunityDomainEvent(this, OpportunityDomainEventType.UpdatedDomainEvent));
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
            AddEvent(new OpportunityDomainEvent(this, OpportunityDomainEventType.OpportunityAddSkillDomainEvent));
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
            AddEvent(new OpportunityDomainEvent(this, OpportunityDomainEventType.OpportunityUpdateSkillDomainEvent));
        }
        public void RemoveSkill(OpportunitySkill Skill)
        {
            var skill = GetSkill(Skill);

            _skills.Remove(Skill);

            AddEvent(new OpportunityDomainEvent(this, OpportunityDomainEventType.OpportunityRemoveSkillDomainEvent));
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

using MatchMe.Common.Shared.Domain;
using MatchMe.Opportunities.Domain.Events;
using MatchMe.Opportunities.Domain.Exceptions;
using MatchMe.Opportunities.Domain.ValueObjects;

namespace MatchMe.Opportunities.Domain.Entities
{
    public class Opportunity : AggregateRoot<OpportunityId>
    {
        public OpportunityId Id { get; }

        private OpportunityName _title;

        private OpportunityDescription _descritption;

        private readonly LinkedList<OpportunitySkill> _skills = new();

        private Opportunity() { }

        internal Opportunity(OpportunityId Id, OpportunityName Title, OpportunityDescription Description)
        {
            this.Id = Id;
            _title = Title;
            _descritption = Description;
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

        public void MandatorySkill(string SkillName)
        {
            var skill = GetSkill(SkillName);
            var newSkill = skill with
            {
                Mandatory = true
            };

            _skills.Find(skill).Value = newSkill;
            AddEvent(new OpportunitySkillMandatoryUpdateEvent(this, skill));
        }
        private OpportunitySkill GetSkill(string SkillName)
        {
            var skill = _skills.SingleOrDefault(a => a.Name == SkillName);

            if(skill is null)
            {
                throw new Exception("");
            }

            return skill;
        }
    }
}

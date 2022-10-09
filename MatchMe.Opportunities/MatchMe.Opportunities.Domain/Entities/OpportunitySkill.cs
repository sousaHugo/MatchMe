using IdGen;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Opportunities.Domain.Entities.Extensions;

namespace MatchMe.Opportunities.Domain.Entities
{
    public class OpportunitySkill : BaseEntity<Identity>
    {
        private OpportunitySkill() { }
        public OpportunitySkill(long Id, string Name, int MinExperience, int MaxExperience, SkillLevelObject Level, bool Mandatory) 
        { 
            this.Id = Id; 
            _name = Name; 
            _minExperience = MinExperience; 
            _maxExperience = MaxExperience; 
            _level = Level; 
            _mandatory = Mandatory;

            this.Validate();
        }
        public OpportunitySkill(string Name, int MinExperience, int MaxExperience, SkillLevelObject Level, bool Mandatory) 
            :this(new IdGenerator(0).CreateId(), Name, MinExperience, MaxExperience, Level, Mandatory){}
        
        private string _name;
        private int _minExperience;
        private int _maxExperience;
        private SkillLevelObject _level;
        private bool _mandatory;

        public string Name => _name;
        public int MinExperience => _minExperience;
        public int MaxExperience => _maxExperience;
        public SkillLevelObject Level => _level;
        public bool Mandatory => _mandatory;
        public OpportunitySkill Update(string Name, int MinExperience, int MaxExperience, SkillLevelObject Level, bool Mandatory)
        => new(Id, Name, MinExperience, MaxExperience, Level, Mandatory);

        public OpportunitySkill IsMandatory(bool Mandatory)
        {
            _mandatory = Mandatory;
            return this;
        }
    }
}

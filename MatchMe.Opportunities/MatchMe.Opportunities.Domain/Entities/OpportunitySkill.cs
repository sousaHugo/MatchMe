using IdGen;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;
using MatchMe.Opportunities.Domain.Entities.Extensions;

namespace MatchMe.Opportunities.Domain.Entities
{
    public partial class OpportunitySkill : BaseEntity<Identity>
    {       
        private readonly string _name;
        private readonly int? _minExperience;
        private readonly int? _maxExperience;
        private readonly SkillLevelObject _level;
        private bool _mandatory;

        public string Name => _name;
        public int? MinExperience => _minExperience;
        public int? MaxExperience => _maxExperience;
        public SkillLevelObject Level => _level;
        public bool Mandatory => _mandatory;
        private OpportunitySkill() { }
        public OpportunitySkill(long Id, string Name, int? MinExperience, int? MaxExperience, SkillLevelObject Level, bool Mandatory)
        {
            this.Id = Id == 0 ? new IdGenerator(0).CreateId() : Id;
            _name = Name;
            _minExperience = MinExperience;
            _maxExperience = MaxExperience;
            _level = Level;
            _mandatory = Mandatory;

            this.Validate();
        }
        public OpportunitySkill(string Name, int? MinExperience, int? MaxExperience, SkillLevelObject Level, bool Mandatory)
            : this(new IdGenerator(0).CreateId(), Name, MinExperience, MaxExperience, Level, Mandatory) { }
    }
}

using IdGen;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Entities
{
    public class CandidateSkill : BaseEntity<Identity>
    {
        public CandidateSkill() { }
        public CandidateSkill(long Id, string Name, int Experience, SkillLevelObject Level) { this.Id = Id; _name = Name; _experience = Experience; _level = Level; }
        public CandidateSkill(string Name, int Experience, SkillLevelObject Level) { Id = new IdGenerator(0).CreateId(); _name = Name; _experience = Experience; _level = Level; }
        
        private string _name;
        private int _experience;
        private SkillLevelObject _level;
        
        public string Name => _name;
        public int Experience => _experience;
        public SkillLevelObject Level => _level;

        
        public void Update(string Name, int Experience, SkillLevelObject Level)
        {
            _name = Name;
            _experience = Experience;
            _level = Level;
        }
    }
}

using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Entities
{
    public partial class CandidateSkill : BaseEntity<Identity>
    {
        private CandidateSkill() { }
        private CandidateSkill(long Id, string Name, int Experience, SkillLevelObject Level) { this.Id = Id; _name = Name; _experience = Experience; _level = Level; }
        
        private string _name;
        private int _experience;
        private SkillLevelObject _level;
        
        public string Name => _name;
        public int Experience => _experience;
        public SkillLevelObject Level => _level;
        
    }
}

using IdGen;
using MatchMe.Candidates.Domain.Entities.Extensions;
using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Candidates.Domain.Entities
{
    public partial class CandidateSkill 
    {
        public static CandidateSkill Create(long Id, string Name, int Experience, SkillLevelObject Level)
        {
            var skill = new CandidateSkill(Id, Name, Experience, Level);
            skill.Validate();

            return skill;
        }
        public static CandidateSkill Create(string Name, int Experience, SkillLevelObject Level)
          => Create(new IdGenerator(0).CreateId(), Name, Experience, Level);

        public void Update(string Name, int Experience, SkillLevelObject Level)
        {
            _name = Name;
            _experience = Experience;
            _level = Level;

            this.Validate();
        }
    }
}

using MatchMe.Common.Shared.Domain.ValueObjects;

namespace MatchMe.Opportunities.Domain.Entities
{
    public partial class OpportunitySkill 
    {       
        public static OpportunitySkill Create(string Name, int? MinExperience, int? MaxExperience, SkillLevelObject Level, bool Mandatory)
            => new(Name, MinExperience, MaxExperience, Level, Mandatory);
        
        public OpportunitySkill Update(string Name, int? MinExperience, int? MaxExperience, SkillLevelObject Level, bool Mandatory)
            => new(Id, Name, MinExperience, MaxExperience, Level, Mandatory);
        
        public OpportunitySkill IsMandatory(bool Mandatory)
        {
            _mandatory = Mandatory;
            return this;
        }
    }
}

using MatchMe.Opportunities.Domain.Exceptions;

namespace MatchMe.Opportunities.Domain.ValueObjects
{
    public record OpportunitySkill
    {
        public string Name { get; }
        public int Experience { get; }
        public bool Mandatory { get; init; }
        public OpportunitySkill(string Name, int Experience, bool Mandatory)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new EmptyOpportunitySkillNameException();

            this.Name = Name;
            this.Experience = Experience;
            this.Mandatory = Mandatory; 
        }
    }
}

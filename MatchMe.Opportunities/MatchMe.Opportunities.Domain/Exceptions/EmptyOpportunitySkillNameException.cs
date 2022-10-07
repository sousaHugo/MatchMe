
using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Opportunities.Domain.Exceptions
{
    internal class EmptyOpportunitySkillNameException : MatchMeException
    {
        public EmptyOpportunitySkillNameException() : base("Opportunity Skill Name cannot be empty.")
        {
        }
    }
}

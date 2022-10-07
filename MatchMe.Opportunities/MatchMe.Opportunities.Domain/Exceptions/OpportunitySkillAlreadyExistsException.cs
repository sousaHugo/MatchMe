using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Opportunities.Domain.Exceptions
{
    public class OpportunitySkillAlreadyExistsException : MatchMeException
    {
        public OpportunitySkillAlreadyExistsException(string OpportunityName, string Skill) 
            : base($"Opportunity: {OpportunityName} already has {Skill} skill defined")
        {
        }
    }
}

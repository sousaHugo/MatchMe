using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Opportunities.Domain.Exceptions
{
    public class EmptyOpportunityNameException : MatchMeException
    {
        public EmptyOpportunityNameException() : base("Opportunity Name cannot be empty.")
        {
        }
    }
}

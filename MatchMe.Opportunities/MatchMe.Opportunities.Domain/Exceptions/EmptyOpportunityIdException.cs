using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Opportunities.Domain.Exceptions
{
    public class EmptyOpportunityIdException : MatchMeException
    {
        public EmptyOpportunityIdException() : base("Opportunity Id cannot be empty.")
        {
        }
    }
}

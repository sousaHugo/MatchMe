using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Opportunities.Domain.Exceptions
{
    public class EmptyOpportunityDescriptionException : MatchMeException
    {
        public EmptyOpportunityDescriptionException() : base("Opportunity Description cannot be empty.")
        {
        }
    }
}

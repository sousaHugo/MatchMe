
using MatchMe.Common.Shared.Exceptions;

namespace MatchMe.Opportunities.Application.Exceptions
{
    public  class OpportunityAlreadyExistsException : MatchMeException
    {
        public string Title { get; set; }

        public OpportunityAlreadyExistsException(string Title) : base($"Opportunity with Title {Title} already exists")
        {
            this.Title = Title;
        }
    }
}

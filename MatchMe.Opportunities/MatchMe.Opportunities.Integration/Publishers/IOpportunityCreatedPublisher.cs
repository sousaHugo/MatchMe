using MatchMe.Opportunities.Integration.Messages;

namespace MatchMe.Opportunities.Integration.Publishers
{
    public interface IOpportunityCreatedPublisher
    {
        void SendMessage(OpportunityCreatedMessageDto MessageDto);
    }
}

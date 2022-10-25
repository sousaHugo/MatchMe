using MatchMe.Common.Shared.Integration;
using MatchMe.Opportunities.Integration.Messages;

namespace MatchMe.Opportunities.Integration.Publishers
{
    public class OpportunityCreatedPublisher : IOpportunityCreatedPublisher
    {
        private readonly IRabbitMQSender _publisher;
        public OpportunityCreatedPublisher(IRabbitMQSender Publisher)
        {
            _publisher = Publisher;
        }
        public void SendMessage(OpportunityCreatedMessageDto MessageDto)
        {
            _publisher.SendMessage(MessageDto, nameof(OpportunityCreatedMessageDto));
        }
    }
}

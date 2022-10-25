using MatchMe.Common.Shared.Integration;
using MatchMe.Candidates.Integration.Messages;

namespace MatchMe.Candidates.Integration.Publishers
{
    public class CandidateCreatedPublisher : ICandidateCreatedPublisher
    {
        private readonly IRabbitMQSender _publisher;
        public CandidateCreatedPublisher(IRabbitMQSender Publisher)
        {
            _publisher = Publisher;
        }
        public void SendMessage(CandidateCreatedMessageDto MessageDto)
        {
            _publisher.SendMessage(MessageDto, nameof(CandidateCreatedMessageDto));
        }
      
    }
}

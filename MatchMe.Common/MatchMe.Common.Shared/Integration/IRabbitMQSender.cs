namespace MatchMe.Common.Shared.Integration
{
    public interface IRabbitMQSender
    {
        void SendMessage(BaseMessageDto baseMessage, string queueName);
    }
}

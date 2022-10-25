using RabbitMQ.Client;

namespace MatchMe.Common.Shared.Integration
{
    public interface IRabbitMQConsumer
    {
        IModel GetQueueToConsume(string QueueName);
    }
}

using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;


namespace MatchMe.Common.Shared.Integration
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQConsumer(IConfiguration Configuration)
        {

            var factory = new ConnectionFactory
            {
                HostName = Configuration["RabbitMQOptions:Host"],
                UserName = Configuration["RabbitMQOptions:Username"],
                Password = Configuration["RabbitMQOptions:Password"]
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public IModel GetQueueToConsume(string QueueName)
        {
            _channel.QueueDeclare(QueueName, false, false, false, null);

            return _channel;
        }
              
    }
}

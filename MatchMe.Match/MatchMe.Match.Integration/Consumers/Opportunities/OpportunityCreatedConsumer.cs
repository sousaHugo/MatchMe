using MatchMe.Common.Shared.Integration;
using MatchMe.Common.Shared.MongoDb;
using MatchMe.Match.Integration.Messages;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MatchMe.Match.Integration.Consumers.Opportunities
{
    public class OpportunityCreatedConsumer : BackgroundService
    {
        private readonly IModel _channel;
        private readonly IMongoRepository<OpportunityCreatedMessageDto> _mongoRepository;
        public OpportunityCreatedConsumer(IMongoRepository<OpportunityCreatedMessageDto> MongoRepository,
            IRabbitMQConsumer Consumer)
        {
            _mongoRepository = MongoRepository;
            _channel = Consumer.GetQueueToConsume(nameof(OpportunityCreatedMessageDto));
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                OpportunityCreatedMessageDto updatePaymentResultMessage = JsonConvert.DeserializeObject<OpportunityCreatedMessageDto>(content);
                HandleMessage(updatePaymentResultMessage).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(nameof(OpportunityCreatedMessageDto), false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(OpportunityCreatedMessageDto MessageDto)
        {
            try
            {
                await _mongoRepository.CreateAsync(MessageDto);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

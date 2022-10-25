using MatchMe.Common.Shared.Integration;
using MatchMe.Common.Shared.MongoDb;
using MatchMe.Match.Integration.Messages;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MatchMe.Match.Integration.Consumers.Candidates
{
    public class CandidateCreatedConsumer : BackgroundService
    {
        private readonly IModel _channel;
        private readonly IMongoRepository<CandidateCreatedMessageDto> _mongoRepository;
        public CandidateCreatedConsumer(IMongoRepository<CandidateCreatedMessageDto> MongoRepository,
            IRabbitMQConsumer Consumer)
        {
            _mongoRepository = MongoRepository;
            _channel = Consumer.GetQueueToConsume(nameof(CandidateCreatedMessageDto));
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                CandidateCreatedMessageDto updatePaymentResultMessage = JsonConvert.DeserializeObject<CandidateCreatedMessageDto>(content);
                HandleMessage(updatePaymentResultMessage).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(nameof(CandidateCreatedMessageDto), false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(CandidateCreatedMessageDto MessageDto)
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

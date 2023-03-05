using Consumer.Interfaces.RabbitMq;
using RabbitMQ.Client;

namespace Consumer
{
    public class Worker : BackgroundService
    {

        private readonly IConsumerService _consumer;
        private readonly IRabbitMqConnection _rabbitMqConnection;

        public Worker(IConsumerService consumer, IRabbitMqConnection rabbitMqConnection)
        {
            _consumer = consumer;
            _rabbitMqConnection = rabbitMqConnection;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connection = _rabbitMqConnection.GetRabbitMqConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "direct.list",
                durable: false,
                exclusive: false,
                autoDelete: true);

            while (!stoppingToken.IsCancellationRequested)
            {
                _consumer.Consume(queueName: "direct.list", IsAcknowledgeAuto: false, channel);

                await Task.Delay(1000, stoppingToken);
            }
        }

    }
}
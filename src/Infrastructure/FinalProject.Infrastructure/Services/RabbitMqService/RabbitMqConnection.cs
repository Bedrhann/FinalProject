using FinalProject.Application.Interfaces.ExternalServices.RabbitMq;
using RabbitMQ.Client;

namespace FinalProject.Infrastructure.Services.RabbitMqService
{
    public class RabbitMqConnection : IRabbitMqConnection
    {
        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory factory = new();
            factory.Uri = new("amqps://vsddpmyk:HMGVhxtSmnCyBnL7AXozqOTHjfoeqRB3@sparrow.rmq.cloudamqp.com/vsddpmyk");

            return factory.CreateConnection();
        }
    }
}

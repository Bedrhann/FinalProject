using RabbitMQ.Client;

namespace Consumer.Interfaces.RabbitMq
{
    public interface IConsumerService
    {
        void Consume(string queueName, bool IsAcknowledgeAuto, IModel channel);
    }
}

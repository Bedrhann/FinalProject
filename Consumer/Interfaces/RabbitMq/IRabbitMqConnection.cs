using RabbitMQ.Client;

namespace Consumer.Interfaces.RabbitMq
{
    public interface IRabbitMqConnection
    {
        IConnection GetRabbitMqConnection();
    }
}

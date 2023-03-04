using RabbitMQ.Client;

namespace FinalProject.Application.Interfaces.ExternalServices.RabbitMq
{
    public interface IRabbitMqConnection
    {
        IConnection GetRabbitMqConnection();
    }
}

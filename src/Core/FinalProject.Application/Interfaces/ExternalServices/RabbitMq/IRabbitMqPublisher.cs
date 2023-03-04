namespace FinalProject.Application.Interfaces.ExternalServices.RabbitMq
{
    public interface IRabbitMqPublisher
    {
        void Publish(object obj, string queue);
    }
}

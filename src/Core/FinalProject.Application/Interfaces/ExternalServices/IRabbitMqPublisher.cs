namespace FinalProject.Application.Interfaces.ExternalServices
{
    public interface IRabbitMqPublisher
    {
        void Publish(object obj, string queue);
    }
}

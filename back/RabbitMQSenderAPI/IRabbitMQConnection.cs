using RabbitMQ.Client;

namespace RabbitMQSenderAPI;

public interface IRabbitMqConnection : IDisposable
{
    bool IsConnected { get; }
    bool TryConnect();
    IModel CreateModel();
}
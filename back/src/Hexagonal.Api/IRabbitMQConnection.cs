using RabbitMQ.Client;

namespace hexagonal.API;

public interface IRabbitMqConnection : IDisposable
{
    bool IsConnected { get; }
    bool TryConnect();
    IModel CreateModel();
}
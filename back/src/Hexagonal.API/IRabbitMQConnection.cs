using RabbitMQ.Client;

namespace Hexagonal.API;

public interface IRabbitMqConnection : IDisposable
{
    bool IsConnected { get; }
    bool TryConnect();
    IModel? CreateModel();
}
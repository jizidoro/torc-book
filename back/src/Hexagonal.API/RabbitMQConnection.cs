using RabbitMQ.Client;

namespace Hexagonal.API;

public class RabbitMqConnection : IRabbitMqConnection
{
    private readonly IConnectionFactory _connectionFactory;
    private IConnection? _connection;
    private bool _disposed;

    public RabbitMqConnection(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        if (!TryConnect())
        {
            throw new InvalidOperationException("Could not establish a connection with RabbitMQ.");
        }
    }

    public bool IsConnected => _connection is {IsOpen: true} && !_disposed;

    public IModel? CreateModel()
    {
        if (!IsConnected)
        {
            throw new InvalidOperationException("No RabbitMQ connections are available to perform this action.");
        }

        return _connection?.CreateModel();
    }

    public bool TryConnect()
    {
        try
        {
            _connection = _connectionFactory.CreateConnection();
        }
        catch (Exception)
        {
            // Log the error here
            return false;
        }

        if (IsConnected)
        {
            // Log successful connection here
            return true;
        }

        return false;
    }

    public void Dispose()
    {
        if (_disposed) return;

        _disposed = true;

        try
        {
            _connection?.Dispose();
        }
        catch (Exception)
        {
            // Log the error here
        }
    }
}
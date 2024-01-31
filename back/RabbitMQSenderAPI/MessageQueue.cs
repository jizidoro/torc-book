using System.Text;
using RabbitMQ.Client;

namespace RabbitMQSenderAPI;

public class MessageQueue : IMessageQueue
{
    private readonly IModel _channel;

    public MessageQueue()
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672/")
        };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();

        _channel.QueueDeclare("messages",
            false,
            false,
            false,
            null);
    }

    public void Send(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish("",
            "messages",
            null,
            body);
    }
}
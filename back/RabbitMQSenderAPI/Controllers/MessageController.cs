using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQSenderAPI.Contracts;

namespace RabbitMQSenderAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController(IMessageQueue messageQueue, IServiceProvider serviceProvider)
    : ControllerBase
{
    private readonly IMessageQueue _messageQueue = messageQueue;

    [HttpPost]
    public IActionResult Post([FromBody] BookDto book)
    {
        var rabbitMqConnection = serviceProvider.GetRequiredService<IRabbitMqConnection>();
        using (var channel = rabbitMqConnection.CreateModel())
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(book));

            channel.BasicPublish("",
                "BookQueue",
                false,
                null,
                body);
        }

        return Ok();
    }
}
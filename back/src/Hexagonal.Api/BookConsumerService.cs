//using System.Threading;
//using hexagonal.Application.Components.BookComponent.Commands;
//using hexagonal.Application.Components.BookComponent.Contracts;
//using Newtonsoft.Json;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;

//namespace hexagonal.API;

//public class BookConsumerService : BackgroundService
//{
//    private readonly IRabbitMqConnection _rabbitMqConnection;
//    private readonly IServiceProvider _services;

//    public BookConsumerService(IRabbitMqConnection rabbitMqConnection, IServiceProvider services)
//    {
//        _rabbitMqConnection = rabbitMqConnection;
//        _services = services;
//    }

//    protected override Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        var consumer = new EventingBasicConsumer(_rabbitMqConnection.CreateModel());

//        consumer.Received += (model, ea) =>
//        {
//            var body = ea.Body;
//            var message = Encoding.UTF8.GetString(body.ToArray());
//            var book = JsonConvert.DeserializeObject<BookCreateDto>(message);

//            using (var scope = _services.CreateScope())
//            {
//                var bookCommand = scope.ServiceProvider.GetRequiredService<IBookCommand>();

//                bookCommand.Create(book);
//            }
//        };

//        _rabbitMqConnection.CreateModel().BasicConsume("BookQueue",
//            true,
//            consumer);

//        return Task.CompletedTask;
//    }
//}


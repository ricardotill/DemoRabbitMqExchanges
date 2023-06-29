using Microsoft.Extensions.Logging;
using RabbitMQ.Client;


namespace RabbitMqWrapper;

public class Context : IContext
{
    public IConnection? Connection { get; }
    public ILogger Logger { get; }


    public Context()
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        Connection = factory.CreateConnection();
    }
}

public class MyEvent
{
    public string Bericht { get; set; }
}

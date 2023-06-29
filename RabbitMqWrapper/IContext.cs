using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace RabbitMqWrapper;

public interface IContext
{
    public IConnection? Connection { get; }
    public ILogger Logger { get; }
}

using System.Text;
using RabbitMQ.Client;

#region Setup
var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

const string message = "Hello World!";
var body = Encoding.UTF8.GetBytes(message);

Console.WriteLine("Ready?");
Console.ReadLine();
Console.Clear();
#endregion

#region Fanout Exchange
Console.WriteLine("Create and publish to Fanout Exchange");

channel.ExchangeDeclare("fanout",
    ExchangeType.Fanout);

channel.BasicPublish(exchange: "fanout",
    routingKey: "hello",
    basicProperties: null,
    body: body);

Console.WriteLine($" [x] Sent '{message}'");

Console.WriteLine("Press [enter] to continue.");
Console.ReadLine();
Console.Clear();
#endregion

#region Direct Exchange
Console.WriteLine("Create and publish to Direct Exchange");

channel.ExchangeDeclare("direct",
    ExchangeType.Direct);

channel.BasicPublish(exchange: "direct",
    routingKey: "routingkey",
    basicProperties: null,
    body: body);
Console.WriteLine($" [x] Sent '{message} with key 'routingkey'");

Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();
Console.Clear();
#endregion

#region Topic Exchange
Console.WriteLine("Create and publish to Topic Exchange\n");

channel.ExchangeDeclare("topic",
    ExchangeType.Topic);

var routingkey1 = "contoso.hr.employee.email";
body = Encoding.UTF8.GetBytes($"Hello! Sent using {routingkey1}");
channel.BasicPublish(exchange: "topic",
    routingKey: routingkey1,
    basicProperties: null,
    body: body);
Console.WriteLine($" [x] Sent to routingkey '{routingkey1}'");
Console.ReadLine();

var routingkey2 = "contoso.crm.employee.email";
body = Encoding.UTF8.GetBytes($"Hello! Sent using {routingkey2}");
channel.BasicPublish(exchange: "topic",
    routingKey: routingkey2,
    basicProperties: null,
    body: body);
Console.WriteLine($" [x] Sent to routingkey '{routingkey2}'");
Console.ReadLine();

var routingkey3 = "contoso.crm.prospect.email";
body = Encoding.UTF8.GetBytes($"Hello! Sent using {routingkey3}");
channel.BasicPublish(exchange: "topic",
    routingKey: routingkey3,
    basicProperties: null,
    body: body);
Console.WriteLine($" [x] Sent to routingkey '{routingkey3}'");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
Console.Clear();
#endregion
﻿using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.BasicQos(0, 10, false);

#region Fanout Exchange
Console.WriteLine("[RunnerThree] Listen to Fanout Exchange\n");

channel.ExchangeDeclare("fanout",
    ExchangeType.Fanout);

channel.QueueDeclare("fanout-queue-3");
channel.QueueBind("fanout-queue-3", "fanout", "random");

var consumerFanout = new EventingBasicConsumer(channel);
consumerFanout.Received += (sender, e) =>
{
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
};

channel.BasicConsume("fanout-queue-3", true, consumerFanout);

Console.WriteLine("Waiting for messages.\n");
Console.ReadLine();
Console.Clear();
#endregion

#region Direct Exchange
var directRouting = "other-routingkey";
Console.WriteLine($"[RunnerThree] Listen to Direct Exchange with key '{directRouting}'\n");

channel.ExchangeDeclare("direct",
    ExchangeType.Direct);

channel.QueueDeclare("direct-queue-3");
channel.QueueBind("direct-queue-3", "direct", directRouting);

var consumerDirect = new EventingBasicConsumer(channel);
consumerDirect.Received += (sender, e) =>
{
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
};

channel.BasicConsume("direct-queue-3", true, consumerDirect);

Console.WriteLine("Waiting for messages.\n");
Console.ReadLine();
Console.Clear();
#endregion

#region Topic Exchange
var topicRouting = "contoso.crm.#";
Console.WriteLine($"[RunnerThree] Listen to Direct Exchange with key '{topicRouting}'\n");

channel.ExchangeDeclare("topic",
    ExchangeType.Topic);

channel.QueueDeclare("topic-queue-3");
channel.QueueBind("topic-queue-3", "topic", topicRouting);

var consumerTopic = new EventingBasicConsumer(channel);
consumerTopic.Received += (sender, e) =>
{
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
};

channel.BasicConsume("topic-queue-3", true, consumerTopic);

Console.WriteLine("Waiting for messages.\n");
Console.ReadLine();
#endregion
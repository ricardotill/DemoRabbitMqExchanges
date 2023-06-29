namespace RabbitMqWrapper;

public class Console
{
    public static void Main()
    {
        var publisher = new Publisher();
        var listener = new Listener();
        Thread.Sleep(10000);
    }
}

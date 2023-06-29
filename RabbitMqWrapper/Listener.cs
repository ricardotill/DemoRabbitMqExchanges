
namespace RabbitMqWrapper;

public class Listener
{
    
    public Listener()
    {
        var context = new Context();
        
        // TODO:
        // Handle and acknowledge the event if an exception occurs requeue it
    }
    
    private void HandleBody(MyEvent stuff)
    {
        System.Console.WriteLine(stuff.Bericht);
    }
    
}

using System.Text;
using Newtonsoft.Json;

namespace RabbitMqWrapper;

public class Publisher
{
    public Publisher()
    {
        var context = new Context();
        
        byte[] body0 = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(new MyEvent{Bericht = "EventNaam"}));
        byte[] body1 = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(new MyEvent{Bericht = "MalFormedEventNaam"}));
        byte[] body2 = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(new MyEvent{Bericht = "Klaasvaak"}));
        byte[] body3 = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(new MyEvent{Bericht = "Pieter Post"}));
        
        
        // TODO:
        // publish all these events.
        


    }
    
}

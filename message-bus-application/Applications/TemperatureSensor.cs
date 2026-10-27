using message_bus_application.Bus;
using message_bus_application.Messages;

namespace message_bus_application.Applications;

// Publisher: knows only the bus and the message type - not who receives the readings.
public class TemperatureSensor
{
    private readonly MessageBus _bus;
    private readonly string _zone;

    public TemperatureSensor(MessageBus bus, string zone)
    {
        _bus = bus;
        _zone = zone;
    }

    public void Measure(double celsius)
    {
        Console.WriteLine($"[Sensor {_zone}]  measured {celsius} °C");
        _bus.Publish(new TemperatureMeasured(_zone, celsius));
    }
}

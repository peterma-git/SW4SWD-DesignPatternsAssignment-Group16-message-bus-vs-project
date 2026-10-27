using message_bus_application.Bus;
using message_bus_application.Messages;

namespace message_bus_application.Applications;

// Subscribes to two message types and receives them from three different
// publishers (two sensors and the alarm monitor) without knowing any of them.
public class Dashboard : IMessageHandler<TemperatureMeasured>, IMessageHandler<AlarmRaised>
{
    public void Handle(TemperatureMeasured message)
    {
        Console.WriteLine($"  [Dashboard]     Zone {message.Zone}: {message.Celsius} °C");
    }

    public void Handle(AlarmRaised message)
    {
        Console.WriteLine($"  [Dashboard]     !! ALARM in zone {message.Zone}: {message.Reason}");
    }
}

using message_bus_application.Bus;
using message_bus_application.Messages;

namespace message_bus_application.Applications;

// Both subscriber (TemperatureMeasured) and publisher (AlarmRaised).
public class AlarmMonitor : IMessageHandler<TemperatureMeasured>
{
    private readonly MessageBus _bus;
    private readonly double _threshold;

    public AlarmMonitor(MessageBus bus, double threshold)
    {
        _bus = bus;
        _threshold = threshold;
    }

    public void Handle(TemperatureMeasured message)
    {
        if (message.Celsius > _threshold)
            _bus.Publish(new AlarmRaised(message.Zone, $"{message.Celsius} °C exceeds {_threshold} °C"));
    }
}

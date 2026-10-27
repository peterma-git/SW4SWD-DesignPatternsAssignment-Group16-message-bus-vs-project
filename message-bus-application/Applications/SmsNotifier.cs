using message_bus_application.Bus;
using message_bus_application.Messages;

namespace message_bus_application.Applications;

// Added later in the demo: plugs into the bus without changing any other class.
public class SmsNotifier : IMessageHandler<AlarmRaised>
{
    public void Handle(AlarmRaised message)
    {
        Console.WriteLine($"  [SmsNotifier]   SMS sent: \"Alarm in zone {message.Zone} - {message.Reason}\"");
    }
}

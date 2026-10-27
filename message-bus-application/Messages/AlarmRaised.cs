using message_bus_application.Bus;

namespace message_bus_application.Messages;

public record AlarmRaised(string Zone, string Reason) : IMessage;

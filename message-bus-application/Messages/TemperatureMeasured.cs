using message_bus_application.Bus;

namespace message_bus_application.Messages;

public record TemperatureMeasured(string Zone, double Celsius) : IMessage;

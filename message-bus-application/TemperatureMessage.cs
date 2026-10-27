namespace message_bus_application;

// Sent by a TemperatureSensor every time it measures a temperature.
public class TemperatureMessage : IMessage
{
    public string Section { get; }
    public double Temperature { get; }

    public TemperatureMessage(string section, double temperature)
    {
        Section = section;
        Temperature = temperature;
    }
}

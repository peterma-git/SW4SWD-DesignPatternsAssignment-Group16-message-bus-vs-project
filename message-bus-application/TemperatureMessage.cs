namespace message_bus_application;

// Sent by a TemperatureSensor every time it measures a temperature.
public class TemperatureMessage : IMessage
{
    public string Section { get; }
    public double TempCelcius { get; }

    public TemperatureMessage(string section, double temperature)
    {
        Section = section;
        TempCelcius = temperature;
    }
}

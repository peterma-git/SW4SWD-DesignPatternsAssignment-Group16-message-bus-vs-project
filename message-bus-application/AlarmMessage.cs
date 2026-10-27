namespace message_bus_application;

// Sent by the AlarmMonitor when a temperature is outside the accepted range.
public class AlarmMessage : IMessage
{
    public string Section { get; }
    public double TempCelcius { get; }
    public string Reason { get; }   // "too hot" or "too cold"

    public AlarmMessage(string section, double temperature, string reason)
    {
        Section = section;
        TempCelcius = temperature;
        Reason = reason;
    }
}

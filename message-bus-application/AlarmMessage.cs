namespace message_bus_application
{
    // Sent by the AlarmMonitor when a temperature is outside the accepted range.
    public class AlarmMessage : IMessage
    {
        public string Section { get; }
        public double Temperature { get; }
        public string Reason { get; }

        public AlarmMessage(string section, double temperature, string reason)
        {
            Section = section;
            Temperature = temperature;
            Reason = reason;
        }
    }
}

namespace message_bus_application;

// Subscriber of TemperatureMessage, and publisher of AlarmMessage.
public class AlarmMonitor : IMessageHandler
{
    private MessageBus _mb;
    private double LowerThreshold { get; } = 18;
    private double UpperThreshold { get; }= 25;

    public AlarmMonitor(MessageBus mb)
    {
        _mb = mb;
        _mb.Subscribe(typeof(TemperatureMessage), this);
    }

    public void HandleMessage(IMessage message)
    {
        if (message is TemperatureMessage)
        {
            TemperatureMessage temperatureMessage = (TemperatureMessage)message;
            CheckTemperature(temperatureMessage);
        }
    }

    private void CheckTemperature(TemperatureMessage message)
    {
        if (message.TempCelcius < LowerThreshold)
        {
            RaiseAlarm(message, "too cold");
        }
        else if (message.TempCelcius > UpperThreshold)
        {
            RaiseAlarm(message, "too hot");
        }
        // Otherwise the temperature is within the accepted range, so we do nothing.
    }

    private void RaiseAlarm(TemperatureMessage message, string reason)
    {
        AlarmMessage alarm = new AlarmMessage(message.Section, message.TempCelcius, reason);
        _mb.Publish(alarm);
    }
}

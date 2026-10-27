namespace message_bus_application;

// Subscriber of TemperatureMessage, and publisher of AlarmMessage.
public class AlarmMonitor : IMessageHandler
{
    private MessageBus _mb;
    private double _minTemperature = 18;
    private double _maxTemperature = 25;

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
        if (message.Temperature < _minTemperature)
        {
            RaiseAlarm(message, "too cold (minimum is " + _minTemperature + " °C)");
        }
        else if (message.Temperature > _maxTemperature)
        {
            RaiseAlarm(message, "too hot (maximum is " + _maxTemperature + " °C)");
        }
        // Otherwise the temperature is within the accepted range, so we do nothing.
    }

    private void RaiseAlarm(TemperatureMessage message, string reason)
    {
        AlarmMessage alarm = new AlarmMessage(message.Section, message.Temperature, reason);
        _mb.Publish(alarm);
    }
}

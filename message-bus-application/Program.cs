namespace message_bus_application;

public class Program
{
    public static void Main(string[] args)
    {
        MessageBus messageBus = new MessageBus();

        // Subscribers (they subscribe themselves to the MessageBus in their constructors)
        InfoScreen infoScreen = new InfoScreen(messageBus);
        AlarmMonitor alarmMonitor = new AlarmMonitor(messageBus);

        // Publishers: one temperature sensor in each section
        TemperatureSensor tomatoSensor = new TemperatureSensor(messageBus, "Tomato Section");
        TemperatureSensor cucumberSensor = new TemperatureSensor(messageBus, "Cucumber Section");

        // Simulate some measurements
        tomatoSensor.Measure(21);
        cucumberSensor.Measure(23);
        tomatoSensor.Measure(27);    // too hot  -> alarm
        cucumberSensor.Measure(16);  // too cold -> alarm
        tomatoSensor.Measure(22);
    }
}

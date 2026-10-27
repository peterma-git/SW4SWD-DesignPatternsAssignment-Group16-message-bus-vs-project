using System;

namespace message_bus_application
{
    // Publisher: sends a TemperatureMessage to the MessageBus every time it measures.
    // It does not know who receives the messages.
    public class TemperatureSensor
    {
        private MessageBus _mb;
        private string _section;

        public TemperatureSensor(MessageBus mb, string section)
        {
            _mb = mb;
            _section = section;
        }

        public void Measure(double temperature)
        {
            Console.WriteLine("Sensor in " + _section + " measured " + temperature + " °C");

            TemperatureMessage message = new TemperatureMessage(_section, temperature);
            _mb.Publish(message);
        }
    }
}

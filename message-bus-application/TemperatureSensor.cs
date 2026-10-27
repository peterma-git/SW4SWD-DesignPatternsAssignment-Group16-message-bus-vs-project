using System;
using System.Diagnostics;
using System.Dynamic;

namespace message_bus_application;

// Publisher: sends a TemperatureMessage to the MessageBus every time it measures.
// It does not know who receives the messages.
public class TemperatureSensor
{
    private MessageBus _mb;
    private string Section { get; }

    public TemperatureSensor(MessageBus mb, string section)
    {
        _mb = mb;
        Section = section;
    }

    public void Measure(double temperature)
    {
        Console.WriteLine("Sensor in " + Section + " measured " + temperature + " °C");

        TemperatureMessage message = new TemperatureMessage(Section, temperature);
        _mb.Publish(message);
    }
}

using message_bus_application.Applications;
using message_bus_application.Bus;
using message_bus_application.Messages;

var bus = new MessageBus();

// Publishers
var sensorA = new TemperatureSensor(bus, "A");
var sensorB = new TemperatureSensor(bus, "B");

// Subscribers
var dashboard = new Dashboard();
var alarmMonitor = new AlarmMonitor(bus, threshold: 30.0);

bus.Subscribe<TemperatureMeasured>(dashboard);
bus.Subscribe<AlarmRaised>(dashboard);
bus.Subscribe<TemperatureMeasured>(alarmMonitor);

Console.WriteLine("=== Part 1: sensors, dashboard and alarm monitor ===");
sensorA.Measure(22.5);
sensorB.Measure(24.0);
sensorB.Measure(31.5);

Console.WriteLine();
Console.WriteLine("=== Part 2: plug in an SmsNotifier - no other class changes ===");
bus.Subscribe<AlarmRaised>(new SmsNotifier());

sensorA.Measure(23.0);
sensorA.Measure(33.0);

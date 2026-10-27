using System;
using System.Collections.Generic;

namespace message_bus_application
{
    // Subscriber of both TemperatureMessage and AlarmMessage.
    // Every time it receives a message, it displays the last 5 messages.
    public class InfoScreen : IMessageHandler
    {
        private MessageBus _mb;
        private List<string> _lastMessages = new List<string>();
        private int _maxMessages = 5;

        public InfoScreen(MessageBus mb)
        {
            _mb = mb;
            _mb.Subscribe(typeof(TemperatureMessage), this);
            _mb.Subscribe(typeof(AlarmMessage), this);
        }

        public void HandleMessage(IMessage message)
        {
            if (message is TemperatureMessage)
            {
                TemperatureMessage temperatureMessage = (TemperatureMessage)message;
                AddMessage(temperatureMessage.Section + ": " + temperatureMessage.Temperature + " °C");
            }
            else if (message is AlarmMessage)
            {
                AlarmMessage alarmMessage = (AlarmMessage)message;
                AddMessage("ALARM! " + alarmMessage.Section + ": " + alarmMessage.Temperature + " °C is " + alarmMessage.Reason);
            }

            Display();
        }

        private void AddMessage(string text)
        {
            _lastMessages.Add(text);

            // Only keep the newest 5 messages: remove the oldest one
            if (_lastMessages.Count > _maxMessages)
            {
                _lastMessages.RemoveAt(0);
            }
        }

        private void Display()
        {
            Console.WriteLine("   +---------------- INFO SCREEN ----------------");
            foreach (string text in _lastMessages)
            {
                Console.WriteLine("   | " + text);
            }
            Console.WriteLine("   +---------------------------------------------");
            Console.WriteLine();
        }
    }
}

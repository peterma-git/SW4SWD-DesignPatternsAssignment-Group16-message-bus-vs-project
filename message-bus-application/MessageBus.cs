using System;
using System.Collections.Generic;

namespace message_bus_application
{
    public class MessageBus
    {
        // Key:   the type of a message, e.g. typeof(TemperatureMessage)
        // Value: the list of subscribers that want messages of that type
        private Dictionary<Type, List<IMessageHandler>> _subscribers = new Dictionary<Type, List<IMessageHandler>>();

        public void Subscribe(Type messageType, IMessageHandler handler)
        {
            // The first time someone subscribes to this message type, create an empty list for it
            if (!_subscribers.ContainsKey(messageType))
            {
                _subscribers[messageType] = new List<IMessageHandler>();
            }

            _subscribers[messageType].Add(handler);
        }

        public void Publish(IMessage message)
        {
            Type messageType = message.GetType();

            // If nobody has subscribed to this message type, there is nothing to do
            if (!_subscribers.ContainsKey(messageType))
            {
                return;
            }

            // Deliver the message to every subscriber of this message type
            List<IMessageHandler> handlers = _subscribers[messageType];
            foreach (IMessageHandler handler in handlers)
            {
                handler.HandleMessage(message);
            }
        }
    }
}

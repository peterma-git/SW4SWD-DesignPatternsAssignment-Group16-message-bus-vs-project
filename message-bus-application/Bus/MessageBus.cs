namespace message_bus_application.Bus;

public class MessageBus
{
    // Key: message type. Value: the handlers subscribed to that type.
    // The list holds IMessageHandler<T> for varying T, so it is typed as object.
    private readonly Dictionary<Type, List<object>> _subscribers = new();

    public void Subscribe<T>(IMessageHandler<T> handler) where T : IMessage
    {
        if (!_subscribers.ContainsKey(typeof(T)))
            _subscribers[typeof(T)] = new List<object>();

        _subscribers[typeof(T)].Add(handler);
    }

    public void Publish<T>(T message) where T : IMessage
    {
        if (!_subscribers.TryGetValue(typeof(T), out var handlers))
            return;

        // Safe cast: handlers stored under typeof(T) were registered as IMessageHandler<T>.
        foreach (IMessageHandler<T> handler in handlers)
            handler.Handle(message);
    }
}

// look into dictionary and find list of subscribers for this specifik MessageType
// Make copy
// Call the handlers in thát copy
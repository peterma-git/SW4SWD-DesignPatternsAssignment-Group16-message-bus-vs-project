namespace message_bus_application.Bus;

// The contract every subscriber implements for each message type it wants to receive.
public interface IMessageHandler<T> where T : IMessage
{
    void Handle(T message);
}

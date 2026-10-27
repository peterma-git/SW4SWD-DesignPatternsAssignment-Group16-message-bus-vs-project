namespace message_bus_application
{
    // Every subscriber implements this interface,
    // so the MessageBus can deliver messages to it.
    public interface IMessageHandler
    {
        void HandleMessage(IMessage message);
    }
}

namespace TreeNewBee.EventBus.Distributed;

public interface IDistributedEventHandler<in TEvent> : IEventHandler
    where TEvent : IDistributedEvent
{
    Task HandleAsync(TEvent @event);
}
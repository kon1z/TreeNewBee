namespace TreeNewBee.EventBus;

public interface ILocalEventHandler<in TEvent> : IEventHandler
    where TEvent : ILocalEvent
{
    Task HandleAsync(TEvent @event);
}
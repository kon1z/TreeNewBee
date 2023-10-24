namespace TreeNewBee.EventBus.Distributed;

public interface IDistributedEventPublisher
{
    Task PublishAsync();
}
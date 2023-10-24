using TreeNewBee.Entities.Events;

namespace TreeNewBee.Entities;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private readonly List<IDomainEvent> _distributedEvents = new();

    private readonly List<IDomainEvent> _localEvents = new();
    public IReadOnlyCollection<IDomainEvent> LocalEvents => _localEvents.AsReadOnly();
    public IReadOnlyCollection<IDomainEvent> DistributedEvents => _distributedEvents.AsReadOnly();

    public virtual void ClearLocalEvents()
    {
        _localEvents.Clear();
    }

    public virtual void ClearDistributedEvents()
    {
        _distributedEvents.Clear();
    }

    protected virtual void AddLocalEvent(IDomainEvent eventData)
    {
        _localEvents.Add(eventData);
    }

    protected virtual void AddDistributedEvent(IDomainEvent eventData)
    {
        _distributedEvents.Add(eventData);
    }
}

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<TKey>
{
    protected AggregateRoot()
    {

    }

    protected AggregateRoot(TKey id)
        : base(id)
    {

    }

    private readonly List<IDomainEvent> _distributedEvents = new();

    private readonly List<IDomainEvent> _localEvents = new();
    public IReadOnlyCollection<IDomainEvent> LocalEvents => _localEvents.AsReadOnly();
    public IReadOnlyCollection<IDomainEvent> DistributedEvents => _distributedEvents.AsReadOnly();

    public virtual void ClearLocalEvents()
    {
        _localEvents.Clear();
    }

    public virtual void ClearDistributedEvents()
    {
        _distributedEvents.Clear();
    }

    protected virtual void AddLocalEvent(IDomainEvent eventData)
    {
        _localEvents.Add(eventData);
    }

    protected virtual void AddDistributedEvent(IDomainEvent eventData)
    {
        _distributedEvents.Add(eventData);
    }
}
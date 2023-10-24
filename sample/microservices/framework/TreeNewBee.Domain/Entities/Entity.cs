namespace TreeNewBee.Entities
{
    public abstract class Entity : IEntity
    {
        public abstract object?[] GetKeys();
    }

    public abstract class Entity<TKey> : IEntity<TKey>
    {
        protected Entity()
        {
        }

        protected Entity(TKey id)
        {
            Id = id;
        }

        public virtual TKey Id { get; protected set; } = default!;
        public abstract object?[] GetKeys();
    }
}

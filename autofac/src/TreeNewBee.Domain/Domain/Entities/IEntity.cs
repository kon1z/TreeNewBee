namespace TreeNewBee.Domain.Entities;

public interface IEntity<TKey>
{
	TKey Id { get; }
}
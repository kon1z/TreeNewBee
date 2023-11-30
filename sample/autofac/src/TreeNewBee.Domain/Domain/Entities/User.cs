namespace TreeNewBee.Domain.Entities;

public class User : IEntity<Guid>
{
	public User(string name)
	{
		Id = Guid.NewGuid();
		Name = name;
	}

	public Guid Id { get; private set; }
	public string Name { get; private set; }
}
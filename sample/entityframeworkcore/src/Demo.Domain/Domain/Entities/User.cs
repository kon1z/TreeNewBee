namespace Demo.Domain.Entities
{
	public class User
    {
		protected User()
		{
		}

		public User(string name)
		{
			Id = Guid.NewGuid();
			Name = name;
		}

		public Guid Id { get; set; }
	    public string Name { get; set; } = null!;
    }
}

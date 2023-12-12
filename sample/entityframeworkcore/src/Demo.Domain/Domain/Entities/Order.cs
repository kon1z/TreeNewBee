namespace Demo.Domain.Entities
{
	public class Order
	{
		private Order()
		{
		}

		public Order(string name, Guid createUserId) 
		{
			Id = Guid.NewGuid();
			Name = name;
			CreateUserId = createUserId;
		}

		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public Guid CreateUserId { get; set; }
	}
}

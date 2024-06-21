namespace Demo.Entities
{
	public class Book : IHasId, IHasCreator
	{
		// For EfCore
		protected Book()
		{
		}

		public Book(string title)
		{
			Title = title;
		}
		public string Title { get; }

		public Guid Id { get; set; }
		public Guid? CreatorUserId { get; set; }

		public override string ToString()
		{
			return $"Entity {typeof(Book).FullName}, Id {Id}, Title {Title}, Creator {CreatorUserId}";
		}
	}
}

namespace Demo
{
	public class FakeCurrentUser : ICurrentUser
	{
		public Guid UserId => Guid.Parse("96CD671D-14AB-4186-9B58-BB787802A7A7");
	}
}

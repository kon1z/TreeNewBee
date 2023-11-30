using System.ComponentModel.DataAnnotations;

namespace TransactionDemo.Host.Entities
{
	public class User
	{
		[Key] public Guid Id { get; set; }
		[Required, MaxLength(128)] public string Name { get; set; } = string.Empty;
	}
}

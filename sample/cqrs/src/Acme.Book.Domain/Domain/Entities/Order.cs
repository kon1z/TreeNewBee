using System;
using Volo.Abp.Domain.Entities;

namespace Acme.Book.Domain.Entities
{
	public class Order : AggregateRoot<Guid>
	{
		public string Name { get; set; }
	}
}

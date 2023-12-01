using Acme.Book.Domain.Entities;
using System;
using Volo.Abp.Domain.Repositories;

namespace Acme.Book.Domain.Repositories
{
	public interface IOrderRepository : IRepository<Order, Guid>
	{
	}
}

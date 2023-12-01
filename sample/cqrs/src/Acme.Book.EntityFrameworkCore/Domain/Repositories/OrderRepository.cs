using Acme.Book.Domain.Entities;
using Acme.Book.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.Book.Domain.Repositories
{
	public class OrderRepository : EfCoreRepository<BookDbContext, Order, Guid>, IOrderRepository
    {
        public OrderRepository(IDbContextProvider<BookDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

using System.Threading.Tasks;
using Acme.Book.Domain.Entities;
using Acme.Book.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.Book.Domain.DomainServices
{
	public class OrderDomainService : DomainService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderDomainService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<Order> CreateAsync(string name)
		{
			return await _orderRepository.InsertAsync(new Order() { Name = name });
		}
	}
}

using Acme.Book.Applications.Orders.Dtos;
using Acme.Book.Domain.DomainServices;
using Acme.Book.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Uow;

namespace Acme.Book.Commends.Orders
{
	[RemoteService(false)]
	public class CreateOrderCommendHandler : BookAppService, IRequestHandler<CreateOrderCommand, OrderDto>
	{
		private readonly OrderDomainService _orderDomainService;

		public CreateOrderCommendHandler(OrderDomainService orderDomainService)
		{
			_orderDomainService = orderDomainService;
		}

		[UnitOfWork(true)]
		public virtual async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var order = await _orderDomainService.CreateAsync(request.Name);

			return ObjectMapper.Map<Order, OrderDto>(order);
		}
	}
}

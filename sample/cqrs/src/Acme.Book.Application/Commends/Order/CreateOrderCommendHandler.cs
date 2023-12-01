using Acme.Book.Applications.Order.Dtos;
using Acme.Book.Domain.DomainServices;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Uow;

namespace Acme.Book.Commends.Order
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

			return ObjectMapper.Map<Domain.Entities.Order, OrderDto>(order);
		}
	}
}

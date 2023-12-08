using MediatR;
using System.Threading.Tasks;
using Acme.Book.Applications.Orders;
using Acme.Book.Applications.Orders.Dtos;
using Acme.Book.Commends.Orders;
using Acme.Book.Queries.Orders;
using Volo.Abp.Application.Dtos;

namespace Acme.Book.Applications.Order
{
	public class OrderAppService : BookAppService, IOrderAppService
    {

	    private readonly IMediator _mediator;

	    public OrderAppService(IMediator mediator)
	    {
		    _mediator = mediator;
	    }

	    public async Task<PagedResultDto<OrderDto>> GetAllAsync(GetAllOrderQuery query)
	    {
		    return await _mediator.Send(query);
	    }

        public async Task<OrderDto> CreateAsync(CreateOrderCommand command)
        {
	        return await _mediator.Send(command);
        }
    }
}

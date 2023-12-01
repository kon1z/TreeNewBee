using Acme.Book.Applications.Order.Dtos;
using Acme.Book.Commends.Order;
using MediatR;
using System.Threading.Tasks;
using Acme.Book.Queries.Order;
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

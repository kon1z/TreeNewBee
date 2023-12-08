using Acme.Book.Applications.Orders.Dtos;
using MediatR;
using Volo.Abp.Application.Dtos;

namespace Acme.Book.Queries.Orders;

public class GetAllOrderQuery : PagedResultRequestDto, IRequest<PagedResultDto<OrderDto>>
{
    public string? Name { get; set; }
}
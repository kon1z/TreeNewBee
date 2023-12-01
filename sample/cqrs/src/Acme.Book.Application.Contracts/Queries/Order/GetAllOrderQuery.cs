using Acme.Book.Applications.Order.Dtos;
using MediatR;
using Volo.Abp.Application.Dtos;

namespace Acme.Book.Queries.Order;

public class GetAllOrderQuery : PagedResultRequestDto, IRequest<PagedResultDto<OrderDto>>
{
    public string? Name { get; set; }
}
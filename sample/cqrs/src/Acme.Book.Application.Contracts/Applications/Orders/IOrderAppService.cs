using System.Threading.Tasks;
using Acme.Book.Applications.Orders.Dtos;
using Acme.Book.Commends.Orders;
using Acme.Book.Queries.Orders;
using Volo.Abp.Application.Dtos;

namespace Acme.Book.Applications.Orders;

public interface IOrderAppService
{
    Task<PagedResultDto<OrderDto>> GetAllAsync(GetAllOrderQuery input);
    Task<OrderDto> CreateAsync(CreateOrderCommand command);
}
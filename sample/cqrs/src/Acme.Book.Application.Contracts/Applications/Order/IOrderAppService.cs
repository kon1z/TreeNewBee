using Acme.Book.Applications.Order.Dtos;
using Acme.Book.Commends.Order;
using Acme.Book.Queries.Order;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.Book.Applications.Order;

public interface IOrderAppService
{
    Task<PagedResultDto<OrderDto>> GetAllAsync(GetAllOrderQuery input);
    Task<OrderDto> CreateAsync(CreateOrderCommand command);
}
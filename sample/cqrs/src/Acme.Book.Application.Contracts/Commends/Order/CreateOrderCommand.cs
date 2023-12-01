using Acme.Book.Applications.Order.Dtos;
using MediatR;

namespace Acme.Book.Commends.Order;

public class CreateOrderCommand : IRequest<OrderDto> 
{
	public string Name { get; set; }
}
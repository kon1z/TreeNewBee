using Acme.Book.Applications.Orders.Dtos;
using MediatR;

namespace Acme.Book.Commends.Orders;

public class CreateOrderCommand : IRequest<OrderDto> 
{
	public string Name { get; set; }
}
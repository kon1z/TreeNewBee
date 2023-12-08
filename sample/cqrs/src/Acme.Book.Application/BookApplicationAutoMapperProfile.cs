using Acme.Book.Applications.Orders.Dtos;
using Acme.Book.Domain.Entities;
using AutoMapper;

namespace Acme.Book;

public class BookApplicationAutoMapperProfile : Profile
{
    public BookApplicationAutoMapperProfile()
    {
	    CreateMap<Order, OrderDto>();
    }
}

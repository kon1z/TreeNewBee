using Acme.Book.Applications.Order.Dtos;
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

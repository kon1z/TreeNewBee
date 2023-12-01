using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Book.Applications.Order.Dtos;

public class OrderDto : EntityDto<Guid>
{
    public string Name { get; set; }
}
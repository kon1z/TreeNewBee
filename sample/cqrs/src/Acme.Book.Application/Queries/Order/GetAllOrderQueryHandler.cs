using Acme.Book.Applications.Order.Dtos;
using Acme.Book.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Uow;

namespace Acme.Book.Queries.Order
{
	[RemoteService(false)]
	public class GetAllOrderQueryHandler : BookAppService, IRequestHandler<GetAllOrderQuery, PagedResultDto<OrderDto>>
	{
		private readonly IOrderRepository _orderRepository;

		public GetAllOrderQueryHandler(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		[UnitOfWork(false)]
		public virtual async Task<PagedResultDto<OrderDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
		{
			var queryable = (await _orderRepository.GetQueryableAsync())
				.WhereIf(!request.Name.IsNullOrEmpty(), x => x.Name.Contains(request.Name));

			var items = await AsyncExecuter.ToListAsync(queryable.OrderBy(x => x.Id)
				.PageBy(request.SkipCount, request.MaxResultCount), cancellationToken);
			var totalCount = await AsyncExecuter.LongCountAsync(queryable, cancellationToken);

			return new PagedResultDto<OrderDto>(totalCount, ObjectMapper.Map<List<Domain.Entities.Order>, List<OrderDto>>(items));
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using TransactionDemo.Host.EntityFrameworkCore;

namespace TransactionDemo.Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
	private readonly AppDbContext _dbContext;

	public HomeController(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	[HttpGet]
	public async Task ShouldHaveTransactionAsync()
	{
		// 开启事务的方法 这个方法可以手动开启 也可以放在中间件里面
		await using var transaction = await _dbContext.Database.BeginTransactionAsync();
		{
			// transaction可以通过入参传递 也可以不传
			await Action(transaction);
			await transaction.CommitAsync();
		}
	}

	private Task Action(IDbContextTransaction transaction)
	{
		_dbContext.Database.UseTransactionAsync(transaction.GetDbTransaction());
		var databaseCurrentTransaction = _dbContext.Database.CurrentTransaction;

		return Task.CompletedTask;
	}
}
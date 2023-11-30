using Microsoft.EntityFrameworkCore.Storage;

namespace TransactionDemo.Host.UnitOfWork;

public interface IUnitOfWork
{
	AsyncLocal<IDbContextTransaction> DbContextTransaction { get; }
	Guid Id { get; set; }
	bool IsCommit { get; set; }
	Task CommitAsync();
	Task RollbackAsync();
}
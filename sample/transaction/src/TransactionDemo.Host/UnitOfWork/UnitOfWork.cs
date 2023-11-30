using Microsoft.EntityFrameworkCore.Storage;

namespace TransactionDemo.Host.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public AsyncLocal<IDbContextTransaction> DbContextTransaction { get; set; }
		public bool IsCommit { get; set; }

		public async Task CommitAsync()
		{
			var transaction = DbContextTransaction.Value;
			if (transaction == null)
			{
				throw new InvalidOperationException("没有开启事务！");
			}

			if (IsCommit)
			{
				throw new InvalidOperationException
			}

			await transaction.CommitAsync();
		}

		public async Task RollbackAsync()
		{
			var transaction = DbContextTransaction.Value;
			if (transaction == null)
			{
				throw new InvalidOperationException("没有开启事务！");
			}

			await transaction.RollbackAsync();
		}
	}
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TreeNewBee.Domain.Entities;
using TreeNewBee.EntityFrameworkCore;

namespace TreeNewBee.Domain.Repositories;

public abstract class EfCoreRepository<TEntity, TKey> : IRepository<TEntity, TKey>
	where TEntity : class, IEntity<TKey>
{
	protected AppDbContext DbContext;

	protected EfCoreRepository(AppDbContext dbContext)
	{
		DbContext = dbContext;
	}

	public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
	{
		return await DbContext.Set<TEntity>().FirstOrDefaultAsync(expression);
	}

	public async Task<List<TEntity>> GetAllAsync()
	{
		return await DbContext.Set<TEntity>().ToListAsync();
	}

	public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
	{
		return await DbContext.Set<TEntity>().Where(expression).ToListAsync();
	}

	public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = true)
	{
		var entityEntry = await DbContext.Set<TEntity>().AddAsync(entity);

		if (autoSave)
		{
			await SaveChangesAsync();
		}

		return entityEntry.Entity;
	}

	public async Task RemoveAllAsync(Expression<Func<TEntity, bool>> expression, bool autoSave = true)
	{
		var all = await GetAllAsync(expression);
		DbContext.Set<TEntity>().RemoveRange(all);

		if (autoSave)
		{
			await SaveChangesAsync();
		}
	}

	public async Task SaveChangesAsync()
	{
		await DbContext.SaveChangesAsync();
	}
}
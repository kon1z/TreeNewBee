using System.Linq.Expressions;
using TreeNewBee.Domain.Entities;

namespace TreeNewBee.Domain.Repositories;

public interface IRepository<TEntity, TKey>
	where TEntity : class, IEntity<TKey>
{
	Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
	Task<List<TEntity>> GetAllAsync();
	Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
	Task<TEntity> InsertAsync(TEntity entity, bool autoSave = true);
	Task RemoveAllAsync(Expression<Func<TEntity, bool>> expression, bool autoSave = true);
	Task SaveChangesAsync();
}
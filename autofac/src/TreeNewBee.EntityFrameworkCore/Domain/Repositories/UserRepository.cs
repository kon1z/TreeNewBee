using TreeNewBee.Domain.Entities;
using TreeNewBee.EntityFrameworkCore;

namespace TreeNewBee.Domain.Repositories;

public class UserRepository : EfCoreRepository<User, Guid>, IUserRepository
{
	public UserRepository(AppDbContext dbContext) : base(dbContext)
	{
	}
}
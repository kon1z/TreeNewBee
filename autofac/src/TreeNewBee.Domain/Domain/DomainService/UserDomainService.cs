using System.Security.AccessControl;
using TreeNewBee.Autofac.DependencyInjection;
using TreeNewBee.Domain.Entities;
using TreeNewBee.Domain.Repositories;

namespace TreeNewBee.Domain.DomainService;

public class UserDomainService : IScopedDependency
{
	private IUserRepository _userRepository;

	public UserDomainService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<User> CreateUserAsync(string name)
	{
		return await _userRepository.InsertAsync(new User(name));
	}
}
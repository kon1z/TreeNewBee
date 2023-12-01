using TreeNewBee.Autofac.DependencyInjection;
using TreeNewBee.Domain.Entities;

namespace TreeNewBee.Domain.DomainService;

public class UserDomainService : ITransientDependency
{
	//private IUserRepository _userRepository;

	//public UserDomainService(IUserRepository userRepository)
	//{
	//	_userRepository = userRepository;
	//}

	public async Task<User> CreateUserAsync(string name)
	{
		//return await _userRepository.InsertAsync(new User(name));
		
		throw new NotImplementedException();
	}
}
using Microsoft.AspNetCore.Mvc;
using TreeNewBee.Domain.DomainService;
using TreeNewBee.Domain.Entities;
using TreeNewBee.Domain.Repositories;
using TreeNewBee.Dtos;

namespace TreeNewBee.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly UserDomainService _userDomainService;
		//private readonly IRepository<User, Guid> _userRepository;

		public UserController(
			UserDomainService userDomainService)
		{
			_userDomainService = userDomainService;
		}

		//[HttpGet("user/{id:guid}")]
		//public async Task<IActionResult> GetUserAsync([FromRoute] Guid id)
		//{
		//	var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == id);
		//	if (user == null)
		//	{
		//		return NotFound(id);
		//	}

		//	return Ok(user);
		//}

		[HttpPost("user")]
		public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto input)
		{
			var user = await _userDomainService.CreateUserAsync(input.UserName);

			return Created($"~/user/{user.Id}", user);
		}

		//[HttpGet("users")]
		//public async Task<IActionResult> GetAllUsersAsync()
		//{
		//	var users = await _userRepository.GetAllAsync();

		//	return Ok(users);
		//}
	}
}

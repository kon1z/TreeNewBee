using AspNetCoreDemo.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class HomeController : ControllerBase
	{
		private readonly HappyOptions _happyOptions;
		private readonly IConfiguration _configuration;

		public HomeController(IOptions<HappyOptions> happyOptions, IConfiguration configuration)
		{
			_configuration = configuration;
			_happyOptions = happyOptions.Value;
		}

		[HttpGet]
		public Task<IActionResult> DoYouHappyAsync()
		{
			return Task.FromResult((IActionResult)Ok(_happyOptions.IsHappy));
		}

		[HttpGet]
		public Task<IActionResult> DoYouHappy2Async()
		{
			return Task.FromResult((IActionResult)Ok(_configuration["Happy:IsHappy"]));
		}
	}
}

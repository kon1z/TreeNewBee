using Microsoft.AspNetCore.Mvc;

namespace TreeNewBee.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		public IActionResult Index()
		{
			return Redirect("~/swagger/index.html");
		}
	}
}

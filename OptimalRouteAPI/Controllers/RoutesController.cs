using Microsoft.AspNetCore.Mvc;
using OptimalRouteAPI.Models;

namespace OptimalRouteAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RoutesController : ControllerBase
	{
		private readonly ILogger<RoutesController> _logger;
		public RoutesController(ILogger<RoutesController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "route")]
		public Models.Route Get()
		{
			return new Models.Route()
			{
				RouteName = "Route",
				StartRoute = "New York",
				EndRoute = "Boston"
			};
		}
	}
}

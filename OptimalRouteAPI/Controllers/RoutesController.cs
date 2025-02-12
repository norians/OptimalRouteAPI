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

		[HttpPost(Name = "optimal-route")]
		public RouteResponse GetOptimalRoute([FromBody] RouteRequest request)
		{
			return new RouteResponse()
			{
				 Route = new List<string>() { "A", "B", "C", "D" },
				 TotalTime= 30,
			};
		}
	}
}

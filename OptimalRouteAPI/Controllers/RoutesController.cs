using Microsoft.AspNetCore.Mvc;
using OptimalRouteAPI.Models;
using OptimalRouteAPI.Services;

namespace OptimalRouteAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RoutesController : ControllerBase
	{
		private readonly ILogger<RoutesController> _logger;
		private readonly IRouteService _routeService;
		public RoutesController(ILogger<RoutesController> logger, IRouteService routeRepository)
		{
			_logger = logger;
			_routeService = routeRepository;
		}

		[HttpPost("optimal-route")]
		public RouteResponse GetOptimalRoute([FromBody] RouteRequest request)
		{
			var route = _routeService.GetOptimalRoute(request);

			return route;
		}
	}
}

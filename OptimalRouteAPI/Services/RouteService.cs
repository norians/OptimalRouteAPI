using OptimalRouteAPI.Models;

namespace OptimalRouteAPI.Services
{
	public interface IRouteService
	{
		/// <summary>
		/// Find all routes from the origin city to the destination, exploring all the possible combinations using stack.
		/// </summary>
		/// <param name="dto">Object containing cities, roads, origin, and destination.</param>
		/// <returns>The route with the shortest time represented as a list of cities.</returns>
		RouteResponse GetOptimalRoute(RouteRequest dto);
	}

	public class RouteService : IRouteService
	{
		public RouteResponse GetOptimalRoute(RouteRequest dto)
		{
			var routes = new Dictionary<List<string>, int>();
			var stack = new Stack<(string CurrentCity, List<string> Path, int Time)>();

			stack.Push((dto.Origin, new List<string> { dto.Origin }, 0));

			while (stack.Count > 0)
			{
				var (currentCity, path, totalTime) = stack.Pop();

				// Save the completed route at the destination
				if (currentCity == dto.Destination)
				{
					routes.Add(new List<string>(path), totalTime);
					continue;
				}

				// Get routes starting from the end of previous route
				var nextRoads = dto.Roads.Where(x => x.From == currentCity).ToList();

				foreach (var road in nextRoads)
				{
					// Expand the path avoiding loops
					if (!path.Contains(road.To)) 
					{
						var newPath = new List<string>(path) { road.To };
						stack.Push((road.To, newPath, totalTime + road.Time));
					}
				}
			}

			if (routes.Any())
			{
				var shorterRoute = routes.OrderBy(x => x.Value).FirstOrDefault();

				return new RouteResponse()
				{
					Route = shorterRoute.Key,
					TotalTime = shorterRoute.Value
				};
			}

			return new RouteResponse();
			
		}
	}
}

namespace OptimalRouteAPI.Models
{
	public class RouteRequest
	{
		public List<string> Cities { get; set; }
		public List<Road> Roads { get; set; }
		public string Origin { get; set; }
		public string Destination { get; set; }
	}
}

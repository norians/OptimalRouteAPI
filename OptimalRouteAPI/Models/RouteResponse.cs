namespace OptimalRouteAPI.Models
{
	public class RouteResponse
	{
		public List<string> Route { get; set; } = new List<string>();
		public int TotalTime { get; set; }
	}
}

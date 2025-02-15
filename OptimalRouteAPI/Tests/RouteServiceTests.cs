using OptimalRouteAPI.Models;
using OptimalRouteAPI.Services;
using System.Linq;
using Xunit;

namespace OptimalRouteAPI.Tests
{
	public class RouteServiceTests
	{
		private readonly RouteService _routeService;

		public RouteServiceTests()
		{
			_routeService = new RouteService();
		}

		/// <summary>
		/// Test: Should find the correct shortest route between two cities.
		/// </summary>
		[Fact]
		public void GetOptimalRoute_SingleRoute_ReturnValidPath()
		{
			var dto = new RouteRequest
			{
				Roads = new List<Road>
			{
				new Road { From = "A", To = "B", Time = 10 },
				new Road { From = "B", To = "C", Time = 15 },
				new Road { From = "C", To = "D", Time = 5 }
			},
				Origin = "A",
				Destination = "D"
			};


			var result = _routeService.GetOptimalRoute(dto);

			var correct = new RouteResponse()
			{
				Route = new List<string> { "A", "B", "C", "D" },
				TotalTime = 30
			};
			Assert.Equivalent(result, correct);
		}

		/// <summary>
		/// Test: Should return an empty list when no route is possible.
		/// </summary>
		[Fact]
		public void GetOptimalRoute_NoRouteExists_ReturnEmptyList()
		{
			// Arrange
			var dto = new RouteRequest
			{
				Roads = new List<Road>
			{
				new Road { From = "A", To = "B", Time = 10 },
				new Road { From = "C", To = "D", Time = 5 }
			},
				Origin = "A",
				Destination = "D"
			};

			var result = _routeService.GetOptimalRoute(dto);

			Assert.Empty(result.Route);
		}

		/// <summary>
		/// Test: Should avoid infinite loops when encountering cycles.
		/// </summary>
		[Fact]
		public void GetOptimalRoute_CycleRoute_ShouldAvoidLoops()
		{
			var dto = new RouteRequest
			{
				Roads = new List<Road>
			{
				new Road { From = "A", To = "B", Time = 10 },
				new Road { From = "B", To = "C", Time = 15 },
				new Road { From = "C", To = "A", Time = 5 },
				new Road { From = "C", To = "D", Time = 10 }
			},
				Origin = "A",
				Destination = "D"
			};

			var result = _routeService.GetOptimalRoute(dto);

			Assert.Equal(new List<string> { "A", "B", "C", "D" }, result.Route);
			Assert.True(result.Route.Count == result.Route.Distinct().Count()); // no cities duplicated
		}
	}
}

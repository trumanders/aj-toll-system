using Business.Models;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleTypeController(IVehicleTypeService _vehicleTypeService) : ControllerBase
{
	[HttpPost("filter-out-toll-free-vehicles")]
	public async Task<IResult> FilterOutTollFreeVehicles(
		[FromBody] List<TollPassageData> tollPassageDataWithVehicleType
	)
	{
		try
		{
			return Results.Ok(
				await _vehicleTypeService.FilterOutTollFreeVehiclesAsync(
					tollPassageDataWithVehicleType
				)
			);
		}
		catch (Exception e)
		{
			return Results.Problem(
				$"An error occurred while filtering out toll free vehicles. Exception: {e.Message}"
			);
		}
	}
}

namespace Api.Controllers;

using AutoMapper;

[Route("api/[controller]")]
[ApiController]
public class VehicleTypeController(IVehicleTypeService _vehicleTypeService, IMapper _mapper) : ControllerBase
{
	[HttpPost("filter-out-toll-free-vehicles")]
	public async Task<IResult> FilterOutTollFreeVehicles([FromBody] List<TollCameraDataDto> tollCameraDataDto)
	{
		try
		{
			var tollCameraModels = _mapper.Map<List<TollCameraData>>(tollCameraDataDto);
			var result = await _vehicleTypeService.FilterOutTollFreeVehiclesAsync(tollCameraModels);
			return Results.Ok(_mapper.Map<List<TollPassageDataDto>>(result));
		}
		catch (Exception e)
		{
			return Results.Problem($"An error occurred while filtering out toll free vehicles. Exception: {e.Message}");
		}
	}
}

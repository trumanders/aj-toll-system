namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimulatedVehicleApiDataController(IDbService _dbService, IMapper _mapper) : ControllerBase
{
	[HttpGet("get-all-simulated-api-data")]
	public async Task<IResult> GetAllSimulatedApiData()
	{
		try
		{
			var simulatedVehicleApiData = await _dbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataModel>();
			return Results.Ok(_mapper.Map<List<SimulatedVehicleApiDataDto>>(simulatedVehicleApiData));
		}
		catch (Exception e)
		{
			return Results.Problem(
				$"An error occurred while retrieving data. Exception: {e.Message}"
			);
		}
	}

	[HttpGet("get-all-plate-numbers")]
	public async Task<IResult> GetAllPlateNumbers()
	{
		try
		{
			var vehiclePlateNumbers = await _dbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataPlateNumber>();

			return Results.Ok(_mapper.Map<SimulatedVehicleApiDataPlateNumberDto>(vehiclePlateNumbers));
		}
		catch (Exception e)
		{
			return Results.Problem(
				$"An error occurred while retrieving data. Exception: {e.Message}"
			);
		}
	}
}

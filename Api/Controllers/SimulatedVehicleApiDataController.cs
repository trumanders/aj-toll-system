namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimulatedVehicleApiDataController : ControllerBase
{
	private readonly IDbService _dbService;

	public SimulatedVehicleApiDataController(IDbService dbService)
	{
		_dbService = dbService;
	}


	[HttpGet]
	public async Task<IResult> Get()
	{
		try
		{
			var simulatedVehicleApiData = await _dbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTO>();
			return Results.Ok(simulatedVehicleApiData);
		}
		catch (Exception e)
		{
			return Results.Problem($"An error occurred while retrieving data. Exception: {e.Message}");
		}
	}

	[HttpGet("platenumbers")]
	public async Task<IResult> GetAllPlateNumbers()
	{
		try
		{
			var vehiclePlateNumbers = await _dbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateNumber>();

			return Results.Ok(vehiclePlateNumbers);
		}
		catch (Exception e)
		{
			return Results.Problem($"An error occurred while retrieving data. Exception: {e.Message}");
		}
	}
}
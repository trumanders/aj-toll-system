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
			var vehicleInfos = await _dbService.GetAsync<Persistence.Entities.SimulatedVehicleApiData, SimulatedVehicleApiDataDTO>();
			return Results.Ok(vehicleInfos);
		}
		catch
		{
			return Results.Problem("An error occurred while retrieving data.");
		}
	}

	[HttpGet("platenumbers")]
	public async Task<IResult> GetAllPlateNumber()
	{
		try
		{
			var plateNumbers = await _dbService.GetAsync<Persistence.Entities.SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateNumber>();
			return Results.Ok(plateNumbers);
		}
		catch
		{
			return Results.Problem("An error occurred while retrieving data.");
		}
	}
}
namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleInfoController : ControllerBase
{
	private readonly IDbService _dbService;

	public VehicleInfoController(IDbService dbService)
	{
		_dbService = dbService;
	}


	[HttpGet]
	public async Task<IResult> Get()
	{
		try
		{
			var vehicleInfos = await _dbService.GetAsync<VehicleInfo, VehicleInfoDTO>();
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
			var plateNumbers = await _dbService.GetAsync<VehicleInfo, VehicleInfoDTOPlateNumber>();
			return Results.Ok(plateNumbers);
		}
		catch
		{
			return Results.Problem("An error occurred while retrieving data.");
		}
	}
}
namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DailyTollCameraDataProcessingController(IDbService _dbService, IMapper _mapper, ITollPassageDataProcessingService _tollPassageDataProcessingService) : ControllerBase
{
	[HttpGet("process-daily-toll-camera-data")]
	public async Task<IResult> ProcessDailyTollCameraData(DateTime date, int numberOfPassages)
	{
		var dailyFees = await _tollPassageDataProcessingService.ProcessDailyTollCameraData(date, numberOfPassages);
		return Results.Ok(dailyFees);
	}
}

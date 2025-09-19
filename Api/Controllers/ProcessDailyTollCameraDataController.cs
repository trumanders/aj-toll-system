namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DailyTollCameraDataProcessingController(IMapper _mapper, ITollCameraDataProcessingService _tollCameraDataProcessingService) : ControllerBase
{
	[HttpGet("process-daily-toll-camera-data")]
	public async Task<IResult> ProcessDailyTollCameraData(DateTime date, int numberOfPassages)
	{
		var dailyFees = await _tollCameraDataProcessingService.ProcessDailyTollCameraData(date, numberOfPassages);
		return Results.Ok(_mapper.Map<List<DailyFeeDto>>(dailyFees));
	}
}

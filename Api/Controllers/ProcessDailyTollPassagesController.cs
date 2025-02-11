namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProcessDailyTollPassagesController : ControllerBase
{
	private readonly ITollDataProcessingService _tollDataProcessingService;

	public ProcessDailyTollPassagesController(ITollDataProcessingService tollDataProcessingService)
	{
		_tollDataProcessingService = tollDataProcessingService;
	}

	/* In a real world scenario, this call is triggered after midnight to process all the passages for the previous day */
	[HttpGet]
	public async Task<IResult> ProcessDailyTollPassages([FromQuery]DateTime date, [FromQuery]int numberOfPassages)
	{
		try
		{
			return Results.Ok(await _tollDataProcessingService.ProcessDailyTollData(date, numberOfPassages));
		}
		catch
		{
			return Results.Problem("An error occurred while retrieving data.");
		}
	}
}
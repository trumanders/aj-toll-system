namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TollPassageController : ControllerBase
{
	private readonly ITollPassageService _tollPassageSerive;

	public TollPassageController(ITollPassageService tollPassageSerive)
	{
		_tollPassageSerive = tollPassageSerive;
	}


	[HttpGet]
	public async Task<IResult> GenerateTollPassages([FromQuery]DateTime date, [FromQuery]int numberOfPassages)
	{
		try
		{
			return Results.Ok(await _tollPassageSerive.GenerateTollPassagesForOneDay(date, numberOfPassages));
		}
		catch
		{
			return Results.Problem("An error occurred while retrieving data.");
		}
	}
}
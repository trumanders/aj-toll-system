namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TollCameraController(
	ITollCameraService _tollCameraService,
	ITollFreeDaysService _tollFreeDaysService
) : ControllerBase
{
	/* In a real world scenario, this call is triggered after midnight to process all the passages for the previous day */
	[HttpGet("get-daily-toll-camera-data")]
	public async Task<IResult> GetDailyTollCameraData(
		[FromQuery] DateTime date,
		[FromQuery] int numberOfPassages
	)
	{
		if (_tollFreeDaysService.IsTollFreeDay(date))
		{
			return Results.Ok(new List<TollCameraDataDTO>());
		} // MOVE TO separate service

		try
		{
			var dailyTollCameraData = await _tollCameraService.GetDailyTollCameraData(
				date,
				numberOfPassages
			);

			var dtos = dailyTollCameraData
				.Select(data => new TollCameraDataDTO
				{
					PlateNumber = data.PlateNumber,
					PassageTime = data.PassageTime,
				})
				.ToList();

			return Results.Ok(dtos);
		}
		catch (Exception e)
		{
			return Results.Problem(
				$"An error occurred while retrieving data. Exception: {e.Message}"
			);
		}
	}
}

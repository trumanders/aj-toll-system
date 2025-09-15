namespace Api.Controllers;

using AutoMapper;

[Route("api/[controller]")]
[ApiController]
public class TollCameraController(
	ITollCameraService _tollCameraService,
	ITollFreeDaysService _tollFreeDaysService,
	IMapper _mapper) : ControllerBase
{
	/* In a real world scenario, this call is triggered after midnight to process all the passages for the previous day */
	[HttpGet("get-daily-toll-camera-data")]
	public async Task<IResult> GetDailyTollCameraData([FromQuery] DateTime date, [FromQuery] int numberOfPassages)
	{
		if (_tollFreeDaysService.IsTollFreeDay(date))
		{
			return Results.Ok(new List<TollCameraDataDto>());
		}

		try
		{
			var dailyTollCameraData = await _tollCameraService.GetDailyTollCameraData(date, numberOfPassages);

			return Results.Ok(_mapper.Map<List<TollCameraDataDto>>(dailyTollCameraData));
		}
		catch (Exception e)
		{
			return Results.Problem(
				$"An error occurred while retrieving data. Exception: {e.Message}"
			);
		}
	}
}

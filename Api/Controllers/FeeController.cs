using Business.Models;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FeeController(IFeeService _feeService) : ControllerBase
{
	[HttpPost("apply-fee-to-all-passages")]
	public async Task<IResult> ApplyFeeToAllPassages([FromBody] List<TollPassageData> tollPassages) // USE DTO here
	{
		try
		{
			return Results.Ok(await _feeService.ApplyFeeToAllPassages(tollPassages));
		}
		catch (Exception e)
		{
			return Results.Problem($"An error occurred while retrieving data. Exception: {e.Message}");
		}
	}

	[HttpPost("get-vehicle-daily-fees")]
	public IResult GetVehicleDailyFees([FromBody] List<TollPassageData> tollPassageData) // Use DTO here
	{
		try
		{
			return Results.Ok(_feeService.GetDailyFeeSummaryForEachVehicle(tollPassageData));
		}
		catch (Exception e)
		{
			return Results.Problem($"An error occurred while retrieving data. Exception: {e.Message}");
		}
	}
}
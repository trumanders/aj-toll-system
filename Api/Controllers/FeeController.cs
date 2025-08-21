using Business.Models;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeeController(IFeeService _feeService) : ControllerBase
{
	[HttpPost("apply-fee-to-all-passages")]
	public async Task<IResult> ApplyFeeToAllPassages([FromBody] List<TollPassageData> tollPassages)
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
}
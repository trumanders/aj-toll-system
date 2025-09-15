namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeeController(IFeeService _feeService, IMapper _mapper) : ControllerBase
{
	[HttpPost("apply-fee-to-all-passages")]
	public async Task<IResult> ApplyFeeToAllPassages([FromBody] List<TollPassageDataDto> tollPassageDataDtos)
	{
		try
		{
			var tollPassageDataModels = _mapper.Map<List<TollPassageData>>(tollPassageDataDtos);
			var result = await _feeService.ApplyFeeToAllPassages(tollPassageDataModels);
			return Results.Ok(_mapper.Map<List<TollPassageDataDto>>(result));
		}
		catch (Exception e)
		{
			return Results.Problem($"An error occurred while retrieving data. Exception: {e.Message}");
		}
	}

	[HttpPost("save-vehicle-daily-fees")]
	public async Task<IResult> SaveVehicleDailyFees([FromBody] List<TollPassageDataDto> tollPassageDataDtos)
	{
		try
		{
			var tollPassageDataModels = _mapper.Map<List<TollPassageData>>(tollPassageDataDtos);
			var savedResult = await _feeService.SaveDailyFeeSummaryForEachVehicle(tollPassageDataModels);
			return Results.Ok(_mapper.Map<List<DailyFeeDto>>(savedResult));
		}
		catch (Exception e)
		{
			return Results.Problem(
				$"An error occurred while retrieving data. Exception: {e.Message}"
			);
		}
	}
}

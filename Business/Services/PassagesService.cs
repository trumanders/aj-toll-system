namespace Business.Services;

public class PassagesService
{
	private readonly IDbService _dbService;
	private readonly IFeeService _feeService;
	private readonly ITollCameraService _tollCameraService;
	private readonly ITollFreeDaysService _tollFreeDaysService;

	private List<TollCameraData> tollCameraData = [];

	public PassagesService(IDbService dbService, ITollCameraService tollCameraService, IFeeService feeService, ITollFreeDaysService tollFreeDaysService)
	{
		_dbService = dbService;
		_tollCameraService = tollCameraService;
		_feeService = feeService;
		_tollFreeDaysService = tollFreeDaysService;
	}

	//public async Task<List<MonthlyFeeDTO>> ProcessDailyTollCameraData()
	//{
	//return new List<MonthlyFeeDTO>();
	//var dailyFeeForEachVehicle = await _feeService.GetDailyFeeSummaryForEachVehicle(new List<TollCameraData>());

	//// Vehicles that are already in monthly fee table (to update)
	//var monthlyFeesToUpdate = await _dbService.GetAsync<MonthlyFee, MonthlyFeeDTO>(entity =>
	//	dailyFeeForEachVehicle.Select(x => x.PlateNumber).Contains(entity.PlateNumber));

	//var monthlyFeesToUpdateLookup = monthlyFeesToUpdate.ToDictionary(dto => dto.PlateNumber);

	//var newMonthlyFees = new List<MonthlyFeeDTO>();

	///* Update or add MonthlyFee */
	//foreach (var vehicleDailyFee in dailyFeeForEachVehicle)
	//{
	//	if (monthlyFeesToUpdateLookup.TryGetValue(vehicleDailyFee.PlateNumber, out var monthlyFeeDto))
	//	{
	//		monthlyFeeDto.AccumulatedFee += vehicleDailyFee.DailyFee;
	//		monthlyFeeDto.Date = date;
	//	}
	//	else
	//	{
	//		newMonthlyFees.Add(new MonthlyFeeDTO()
	//		{
	//			PlateNumber = vehicleDailyFee.PlateNumber,
	//			AccumulatedFee = vehicleDailyFee.DailyFee,
	//			Date = date
	//		});
	//	}
	//}

	//// Update Monthly Fees by plate number
	//if (monthlyFeesToUpdateLookup.Count > 0)
	//	await _dbService.Update<MonthlyFee, MonthlyFeeDTO>(e => monthlyFeesToUpdateLookup.Values
	//			.Select(dto => dto.PlateNumber)
	//				.Contains(e.PlateNumber), monthlyFeesToUpdateLookup.Values.ToList());

	//// Add new vehicles to monthly fees
	//if (newMonthlyFees.Count > 0)
	//	await _dbService.AddAsync<MonthlyFee, MonthlyFeeDTO>(newMonthlyFees);

	//await _dbService.SaveChangesAsync();

	//var updatedMonthlyFees = await _dbService.GetAsync<MonthlyFee, MonthlyFeeDTO>();

	//return updatedMonthlyFees;
	//}
}

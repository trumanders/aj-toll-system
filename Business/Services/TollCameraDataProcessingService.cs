namespace Business.Services;

public class TollCameraDataProcessingService : ITollCameraDataProcessingService
{
	private readonly IDbService _dbService;
	private readonly IFeeService _feeService;
	private readonly ITollCameraService _tollCameraService;
	private readonly ITollFreeDaysService _tollFreeDaysService;

	public TollCameraDataProcessingService(IDbService dbService, ITollCameraService tollCameraService, IFeeService feeService, ITollFreeDaysService tollFreeDaysService)
	{
		_dbService = dbService;
		_tollCameraService = tollCameraService;
		_feeService = feeService;
		_tollFreeDaysService = tollFreeDaysService;
	}


	public async Task<ProcessedPassages> ProcessDailyTollCameraData(DateTime date, int numberOfTollPassages)
	{
		if (_tollFreeDaysService.IsTollFreeDay(date))
		{
			// return empty list
		}

		var dailyTollCameraData = await _tollCameraService.GenerateDailyTollCameraData(date, numberOfTollPassages);

		if (!dailyTollCameraData.Any()) { return new ProcessedPassages(); }

		// Get info on each vehicle from the simulated vehicle API
		var vehiclePlateAndTypeForAllPassages = await _dbService.GetWithExpressionAndIncludesAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateAndType>(
			vi => dailyTollCameraData
				.Select(dtp => dtp.PlateNumber)
				.Contains(vi.PlateNumber),
			vi => vi.VehicleType);

		RemoveTollFreeVehicles(dailyTollCameraData, vehiclePlateAndTypeForAllPassages);
		
		/* FeeIntervalRepository*/
		var dailyFeeForEachVehicle = await _feeService.GetDailyFeeSummaryForEachVehicle(dailyTollCameraData);

		/* MontlyFeeRepository */ // Vehicles that are already in monthly fee table (to update) 
		var monthlyFeesToUpdate = await _dbService.GetAsync<MonthlyFee, MonthlyFeeDTO>(entity =>
			dailyFeeForEachVehicle.Select(vdf => vdf.PlateNumber).Contains(entity.PlateNumber));

		var monthlyFeesToUpdateLookup = monthlyFeesToUpdate.ToDictionary(dto => dto.PlateNumber);

		var newVehicles = new List<MonthlyFeeDTO>();

		/* Update or add MonthlyFee */
		foreach (var vehicleDailyFee in dailyFeeForEachVehicle)
		{			
			if (monthlyFeesToUpdateLookup.TryGetValue(vehicleDailyFee.PlateNumber, out var monthlyFeeDto))
			{
				monthlyFeeDto.AccumulatedFee += vehicleDailyFee.DailyFee;
				monthlyFeeDto.Date = date;
			}
			else
			{
				newVehicles.Add(new MonthlyFeeDTO()
				{
					PlateNumber = vehicleDailyFee.PlateNumber,
					AccumulatedFee = vehicleDailyFee.DailyFee,
					Date = date
				});
			}
		}

		// Update Monthly Fees by plate number		
		if (monthlyFeesToUpdateLookup.Count > 0)
			await _dbService.Update<MonthlyFee, MonthlyFeeDTO>(e => monthlyFeesToUpdateLookup.Values
					.Select(dto => dto.PlateNumber)
						.Contains(e.PlateNumber), monthlyFeesToUpdateLookup.Values.ToList());		

		// Add new vehicles to monthly fees
		if (newVehicles.Count > 0)
			await _dbService.AddAsync<MonthlyFee, MonthlyFeeDTO>(newVehicles);

		await _dbService.SaveChangesAsync();

		var updatedMonthlyFees = await _dbService.GetAsync<MonthlyFee, MonthlyFeeDTO>();

		var processedTollData = new ProcessedPassages()
		{
			TollCameraData = dailyTollCameraData,
			VehiclesDailyFees = dailyFeeForEachVehicle,
			MonthlyFees = updatedMonthlyFees
		};

		return processedTollData;
	}

	private void RemoveTollFreeVehicles(List<TollCameraData> dailyTollCameraData, List<SimulatedVehicleApiDataDTOPlateAndType> vehiclePlateAndTypeForAllPassages)
	{
		dailyTollCameraData.RemoveAll(data => 
			vehiclePlateAndTypeForAllPassages
				.Single(plateAndType => plateAndType.PlateNumber == data.PlateNumber)
				.VehicleType.IsTollFree
		);
	}
}

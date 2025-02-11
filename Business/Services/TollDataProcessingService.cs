namespace Business.Services;

public class TollDataProcessingService : ITollDataProcessingService
{
	private readonly IDbService _dbService;
	private readonly IFeeService _feeService;
	private readonly ITollPassageService _tollPassageService;
	private readonly ITollFreeDaysService _tollFreeDaysService;

	public TollDataProcessingService(IDbService dbService, ITollPassageService tollPassageService, IFeeService feeService, ITollFreeDaysService tollFreeDaysService)
	{
		_dbService = dbService;
		_tollPassageService = tollPassageService;
		_feeService = feeService;
		_tollFreeDaysService = tollFreeDaysService;
	}

	public async Task<ProcessedTollData> ProcessDailyTollData(DateTime date, int numberOfTollPassages)
	{
		if (_tollFreeDaysService.IsTollFreeDay(date))
		{
			// return empty list
		}

		var dailyTollPassages = await _tollPassageService.GenerateTollPassagesForOneDay(date, numberOfTollPassages);

		if (!dailyTollPassages.Any()) { return new ProcessedTollData(); }

		/* VehicleInfoRepository */
		var vehiclePlateAndTypeForAllPassages = await _dbService.GetWithExpressionAndIncludesAsync<VehicleInfo, VehicleInfoDTOPlateAndType>(
			vi => dailyTollPassages
				.Select(dtp => dtp.PlateNumber)
				.Contains(vi.PlateNumber),
			vi => vi.VehicleType);

		RemoveTollFreeVehicles(dailyTollPassages, vehiclePlateAndTypeForAllPassages);
		
		/* FeeIntervalRepository*/
		var vehiclesDailyFees = await _feeService.GetDailyFeeSummaryForEachVehicle(dailyTollPassages);

		/* MontlyFeeRepository */ // Vehicles that are already in monthly fee table (to update) 
		var monthlyFeesToUpdate = await _dbService.GetAsync<MonthlyFee, MonthlyFeeDTO>(entity =>
			vehiclesDailyFees.Select(vdf => vdf.PlateNumber).Contains(entity.PlateNumber));

		var monthlyFeesToUpdateLookup = monthlyFeesToUpdate.ToDictionary(dto => dto.PlateNumber);

		var newVehicles = new List<MonthlyFeeDTO>();

		/* Update or add MonthlyFee */
		foreach (var vehicleDailyFee in vehiclesDailyFees)
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

		var processedTollData = new ProcessedTollData()
		{
			TollPassages = dailyTollPassages,
			VehiclesDailyFees = vehiclesDailyFees,
			MonthlyFees = updatedMonthlyFees
		};

		return processedTollData;
	}

	private void RemoveTollFreeVehicles(List<TollPassage> dailyTollPassages, List<VehicleInfoDTOPlateAndType> vehiclePlateAndTypeForAllPassages)
	{
		dailyTollPassages.RemoveAll(dtp => 
			vehiclePlateAndTypeForAllPassages
				.Single(plateAndType => plateAndType.PlateNumber == dtp.PlateNumber)
				.VehicleType.IsTollFree
		);
	}
}

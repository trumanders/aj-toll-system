namespace Business.Services;

public class TollPassageService : ITollPassageService
{
	private readonly IDbService _dbService;
	private readonly IFeeService _feeService;
	private readonly ITollFreeDaysService _tollFreeDaysService;
	private const int secondsWithinOneDay = 86399;
	public TollPassageService(IDbService dbService, IFeeService feeService, ITollFreeDaysService tollFreeDaysService)
	{
		_dbService = dbService;
		_feeService = feeService;
		_tollFreeDaysService = tollFreeDaysService;
	}

	public async Task<List<TollPassageNoFee>> GenerateTollPassagesForOneDay(DateTime date, int numberOfPassages)
	{
		var plateNumbers = await _dbService.GetAsync<VehicleInfo, VehicleInfoDTOPlateNumber>();
		var tollPassages = new List<TollPassageNoFee>();
		var random = new Random();

		// Generate specified number of passages
		// and randomize plate numbers and passage datetimes within the 
		// specified date
		for (int i = 0; i < numberOfPassages; i++)
		{
			tollPassages.Add(new TollPassageNoFee
			{
				PlateNumber = plateNumbers[random.Next(0, plateNumbers.Count)].PlateNumber,
				PassageTime = date.AddSeconds(random.Next(0, secondsWithinOneDay))
			});
		}
		
		return tollPassages.OrderBy(x => x.PassageTime).ToList();
	}

	public async Task<List<VehicleDailyFee>> GetDailyFeeSummaryForEachVehicle(List<TollPassage> tollPassages)
	{
		// Check for toll free day
		if (_tollFreeDaysService.IsTollFreeDay(tollPassages.First().PassageTime))
		{
			return new List<VehicleDailyFee>();
		}

		// Group passages by plate number
		var passagesByPlateNumber = tollPassages
			.GroupBy(x => x.PlateNumber)
			.Select(g => g.ToList())
			.ToList();

		// Get list of plate numbers and their daily fee
		var vehicleDailyFees = new List<VehicleDailyFee>();
		foreach (var vehiclePassages in passagesByPlateNumber)
		{
			vehicleDailyFees.Add(await _feeService.GetTotalFeeForVehiclePassages(vehiclePassages));
		}

		return vehicleDailyFees;
	}
}
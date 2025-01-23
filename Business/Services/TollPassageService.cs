namespace Business.Services;

public class TollPassageService : ITollPassageService
{
	private readonly IDbService _dbService;
	private readonly IFeeService _feeService;
	private const int secondsWithinOneDay = 86399;
	public TollPassageService(IDbService dbService, IFeeService feeService)
	{
		_dbService = dbService;
		_feeService = feeService;
	}

	public async Task<List<TollPassage>> GenerateTollPassagesForOneDay(DateTime date, int numberOfPassages)
	{
		var plateNumbers = await _dbService.GetAsync<VehicleInfo, VehicleInfoDTOPlateNumber>();
		var tollPassages = new List<TollPassage>();
		var random = new Random();

		// Generate specified number of passages
		// and randomize plate numbers and passage datetimes within the 
		// specified date
		for (int i = 0; i < numberOfPassages; i++)
		{
			tollPassages.Add(new TollPassage
			{
				PlateNumber = plateNumbers[random.Next(0, plateNumbers.Count)].PlateNumber,
				PassageTime = date.AddSeconds(random.Next(0, secondsWithinOneDay))
			});
		}
		
		return tollPassages.OrderBy(x => x.PassageTime).ToList();
	}

	public async Task<List<VehicleDailyFee>> GetVehicleFeeSummary(List<TollPassage> tollPassages)
	{
		// List of TollPassage-lists for each platenumber
		var passagesByPlateNumber = tollPassages
			.GroupBy(x => x.PlateNumber)
			.Select(g => g.ToList())
			.ToList();

		var vehicleDailyFeeTasks = passagesByPlateNumber.Select(vehiclePassages => 
			_feeService.GetTotalFeeForVehiclePassages(vehiclePassages)).ToList();

		var vehicleDailyFees = await Task.WhenAll(vehicleDailyFeeTasks);

		return vehicleDailyFees.ToList();
	}
}
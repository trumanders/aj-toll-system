namespace Business.Services;

public class FeeService : IFeeService
{
	private ITollFreeDaysService _tollFreeDaysService;
	private IDbService _dbService;
	static readonly TimeSpan _singleChargeInterval = TimeSpan.FromHours(1);
	const int MAX_DAILY_FEE = 60;


	public FeeService(ITollFreeDaysService tollFreeDayService)
	{
		_tollFreeDaysService = tollFreeDayService;
	}	

	public async Task<VehicleDailyFee> GetTotalFeeForVehiclePassages(List<TollPassage> vehicleTollPassages)
	{
		// KOLLA TOLL FREE DAY INNAN ANROPA DENNA METOD EFTERSOM ALLA PASSAGER ÄR SAMMA DATUM HÄR!
		
		if (vehicleTollPassages.Select(x => x.PlateNumber).Distinct().Count() > 1)
		{
			throw new ArgumentException("All passages must be for the same vehicle.", nameof(vehicleTollPassages));
		}

		// TODO: Cache this value to prevent multiple calls to the database
		var feeIntervals = await _dbService.GetAsync<FeeInterval, FeeIntervalDTO>();

		foreach (var tollPassage in vehicleTollPassages)
		{
			foreach (var feeInterval in feeIntervals)
			{
				if (tollPassage.PassageTime.TimeOfDay >= feeInterval.Start && tollPassage.PassageTime.TimeOfDay < feeInterval.End)
				{
					tollPassage.Fee = feeInterval.Fee;
				}
			}
		}

		CalculateFeeDue(vehicleTollPassages);
		
		var vehicleDailyFee = new VehicleDailyFee
		{
			PlateNumber = vehicleTollPassages.First().PlateNumber,
			DailyFee = GetTotalFeeForPassages(vehicleTollPassages),
		};

		return vehicleDailyFee;
	}

	public void CalculateFeeDue(List<TollPassage> tollPassages)
	{
		if (tollPassages == null)
			throw new ArgumentNullException(nameof(tollPassages), "Toll passages list cannot be null.");

		if (tollPassages.Count == 0)
			throw new ArgumentException("Toll passages list cannot be empty.", nameof(tollPassages));

		var firstPassageWithFee = tollPassages.FirstOrDefault(passage => passage.Fee > 0)
			?? tollPassages.First();

		var intervalStart = firstPassageWithFee.PassageTime;
		var highestFeePassageInInterval = firstPassageWithFee;

		foreach (var tollPassage in tollPassages)
		{
			if (IsPassageWithinInterval(intervalStart, tollPassage.PassageTime, _singleChargeInterval))
			{
				if (tollPassage.Fee > highestFeePassageInInterval.Fee)
				{
					highestFeePassageInInterval = tollPassage;
				}
				tollPassage.Fee = 0;
			}
			else
			{
				highestFeePassageInInterval = tollPassage;
				intervalStart = tollPassage.PassageTime;
			}
		}
	}

	private decimal GetTotalFeeForPassages(List<TollPassage> tollPassages)
	{
		if (tollPassages == null)
			throw new ArgumentNullException(nameof(tollPassages), "Toll passages list cannot be null.");
		if (tollPassages.Count == 0)
			throw new ArgumentException("Toll passages list cannot be empty.", nameof(tollPassages));

		var totalFee = tollPassages.Sum(passage => passage.Fee);
		return totalFee > MAX_DAILY_FEE ? MAX_DAILY_FEE : totalFee;
	}

	private bool IsPassageWithinInterval(DateTime start, DateTime end, TimeSpan timeSpan)
	{
		return end - start < timeSpan;
	}
}
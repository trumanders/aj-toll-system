using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Business.Services;

public class FeeService : IFeeService
{
	private IDbService _dbService;
	static readonly TimeSpan _singleChargeInterval = TimeSpan.FromHours(1);
	
	private const decimal MAX_DAILY_FEE = 60;

	public FeeService(IDbService dbService)
	{
		_dbService = dbService;
	}

	public decimal GetMaxDailyFee()
	{
		return MAX_DAILY_FEE;
	}

	public async Task<List<VehicleDailyFee>> GetDailyFeeSummaryForEachVehicle(List<TollCameraData> cameraData)
	{		
		var feeIntervals = await _dbService.GetAsync<FeeInterval, FeeIntervalDTO>();

		if (feeIntervals.Count == 0)
		{
			throw new InvalidOperationException("Fee intervals are not set.");
		}

		var cameraDataByPlateNumber = cameraData
			.GroupBy(x => x.PlateNumber)
			.Select(g => g.ToList())
			.ToList();

		var vehicleDailyFees = new List<VehicleDailyFee>();

		foreach (var dataPerPlateNumber in cameraDataByPlateNumber)
		{
			var vehicleDailyFee = GetVehicleDailyFee(dataPerPlateNumber, feeIntervals);
			
			if (vehicleDailyFee.DailyFee != 0)
				vehicleDailyFees.Add(vehicleDailyFee);
		}

		return vehicleDailyFees;
	}

	#region Private Methods
	private VehicleDailyFee GetVehicleDailyFee(List<TollCameraData> vehicleDailyTollCameraData, List<FeeIntervalDTO> feeIntervals)
	{
		if (vehicleDailyTollCameraData.Select(x => x.PlateNumber).Distinct().Count() > 1)
		{
			throw new ArgumentException("All passages must be for the same vehicle.", nameof(vehicleDailyTollCameraData));
		}

		var tollPassagesData = new List<TollPassageData>();
		foreach (var cameraData in vehicleDailyTollCameraData)
		{
			var tollPassageData = new TollPassageData
			{
				PlateNumber = cameraData.PlateNumber,
				PassageTime = cameraData.PassageTime,
				Fee = 0
			};

			foreach (var feeInterval in feeIntervals)
			{
				if (cameraData.PassageTime.TimeOfDay >= feeInterval.Start && cameraData.PassageTime.TimeOfDay < feeInterval.End)
				{
					tollPassageData.Fee = feeInterval.Fee;
				}
			}

			tollPassagesData.Add(tollPassageData);
		}

		CalculateFeeDue(tollPassagesData);

		var totalFee = tollPassagesData.Sum(passage => passage.Fee);
		var vehicleDailyFee = new VehicleDailyFee
		{
			PlateNumber = tollPassagesData.First().PlateNumber,
			DailyFee = totalFee > MAX_DAILY_FEE ? MAX_DAILY_FEE : totalFee
		};

		return vehicleDailyFee;
	}


	private void CalculateFeeDue(List<TollPassageData> tollPassages)
	{
		if (tollPassages.Select(x => x.PlateNumber).Distinct().Count() > 1)
			throw new ArgumentException("All passages must be for the same vehicle.", nameof(tollPassages));

		if (tollPassages == null)
			throw new ArgumentNullException(nameof(tollPassages), "Toll passages list cannot be null.");

		if (tollPassages.Count == 0)
			throw new ArgumentException("Toll passages list cannot be empty.", nameof(tollPassages));

		var firstPassageWithFee = tollPassages.FirstOrDefault(passage => passage.Fee > 0)
			?? tollPassages.First();

		var intervalStart = firstPassageWithFee;
		var highestFeePassageInInterval = firstPassageWithFee;

		// Start iterating from element after intervalStart / highestFeePassageInInterval
		foreach (var tollPassage in tollPassages.SkipWhile(passage => passage != intervalStart).Skip(1))
		{
			if (IsPassageWithinInterval(tollPassage.PassageTime, intervalStart.PassageTime, _singleChargeInterval))
			
			{
				if (tollPassage.Fee >= highestFeePassageInInterval.Fee)
				{
					highestFeePassageInInterval.Fee = 0;
					highestFeePassageInInterval = tollPassage;
				}
				else
				{
					tollPassage.Fee = 0;
				}				
			}
			else
			{
				highestFeePassageInInterval = tollPassage;
				intervalStart = tollPassage;
			}
		}
	}	

	private bool IsPassageWithinInterval(DateTime end, DateTime start, TimeSpan timeSpan)
	{
		return end - start < timeSpan;
	}
	#endregion
}
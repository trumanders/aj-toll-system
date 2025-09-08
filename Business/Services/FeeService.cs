namespace Business.Services;

public class FeeService(IDbService _dbService) : IFeeService
{
	static readonly TimeSpan _singleChargeInterval = TimeSpan.FromHours(1);

	private const decimal maxDailyFee = 60;

	public decimal GetMaxDailyFee()
	{
		return maxDailyFee;
	}

	public async Task<List<TollPassageData>> ApplyFeeToAllPassages(List<TollPassageData> tollPassageData)
	{
		var feeIntervals = await _dbService.GetAsync<FeeInterval, FeeIntervalDTO>();

		if (feeIntervals.Count == 0)
		{
			throw new InvalidOperationException("There are no fee intervals available.");
		}

		var passagesByPlateNumberWithFeeApplied = tollPassageData
			.GroupBy(x => x.PlateNumber)
				.Select(plateNumberGroup =>
				{
					var passagesWithFee = plateNumberGroup
						.Select(passage =>
						{
							passage.Fee = feeIntervals
								.FirstOrDefault(feeInterval => passage.PassageTime.TimeOfDay >= feeInterval.Start &&
									passage.PassageTime.TimeOfDay < feeInterval.End)
								?.Fee ?? 0;
							return passage;
						})
						.ToList();

					ApplyFeeDiscontToPassages(passagesWithFee);
					RemoveZeroFees(passagesWithFee);

					return passagesWithFee;
				})
				.ToList();

		return [.. passagesByPlateNumberWithFeeApplied.SelectMany(plateNumberGroup => plateNumberGroup)];
	}

	public List<VehicleDailyFee> GetDailyFeeSummaryForEachVehicle(List<TollPassageData> passageData)
	{
		if (passageData.Any(x => x.Fee == null))
		{
			throw new InvalidOperationException(
				"The passages must have fees applied to calculate the total daily fee"
			);
		}

		var passasgesByPlatenumber = passageData
			.GroupBy(x => x.PlateNumber)
			.Select(g => g.ToList())
			.ToList();

		var vehicleDailyFees = new List<VehicleDailyFee>();

		foreach (var platenumberGroup in passasgesByPlatenumber)
		{
			vehicleDailyFees.Add(
				new VehicleDailyFee()
				{
					PlateNumber = platenumberGroup.First().PlateNumber,
					DailyFee = CalculateTotalDailyFeeForVehicle(platenumberGroup),
					Date = platenumberGroup.First().PassageTime.Date,
				}
			);
		}

		return vehicleDailyFees;
	}

	// MONTHLY FEE LOGIC HERE:

	#region Private Methods

	private decimal? CalculateTotalDailyFeeForVehicle(List<TollPassageData> dailyFeesForVehicle)
	{
		var dailyFee = dailyFeesForVehicle.Sum(x => x.Fee);

		return dailyFee > maxDailyFee ? maxDailyFee : dailyFee;
	}

	private void ApplyFeeDiscontToPassages(List<TollPassageData> tollPassages)
	{
		if (tollPassages.Select(x => x.PlateNumber).Distinct().Count() > 1)
			throw new ArgumentException(
				"All passages must be for the same vehicle.",
				nameof(tollPassages)
			);

		if (tollPassages == null)
			throw new ArgumentNullException(
				nameof(tollPassages),
				"Toll passages list cannot be null when applying fee discount."
			);

		if (tollPassages.Count == 0)
			throw new ArgumentException(
				"Toll passages list cannot be empty when applying fee discount.",
				nameof(tollPassages)
			);

		var firstPassageWithFee =
			tollPassages.FirstOrDefault(passage => passage.Fee > 0) ?? tollPassages.First();

		var intervalStart = firstPassageWithFee;
		var highestFeePassageInInterval = firstPassageWithFee;

		// Start iterating from element after intervalStart / highestFeePassageInInterval
		foreach (
			var tollPassage in tollPassages.SkipWhile(passage => passage != intervalStart).Skip(1)
		)
		{
			if (
				IsPassageWithinInterval(
					tollPassage.PassageTime,
					intervalStart.PassageTime,
					_singleChargeInterval
				)
			)
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

	private void RemoveZeroFees(List<TollPassageData> tollPassagesWithFee)
	{
		tollPassagesWithFee.RemoveAll(x => x.Fee == 0);
	}
	#endregion
}

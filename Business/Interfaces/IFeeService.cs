namespace Business.Interfaces;

public interface IFeeService
{
	public Task<List<TollPassageData>> ApplyFeeToAllPassages(List<TollPassageData> tollPassageData);

	public List<VehicleDailyFee> GetDailyFeeSummaryForEachVehicle(
		List<TollPassageData> tollPassageData
	);
	public decimal GetMaxDailyFee();
}

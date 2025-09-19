namespace Business.Interfaces;

public interface IFeeService
{
	public Task<List<TollPassageData>> ApplyFeeToAllPassages(List<TollPassageData> tollPassageData);

	public List<VehicleDailyFee> CreateDailyFeeSummaryForEachVehicle(List<TollPassageData> passageData);
	public Task<List<VehicleDailyFee>> SaveDailyFeeSummaryForEachVehicle(List<TollPassageData> passageData);

	public decimal GetMaxDailyFee();
}

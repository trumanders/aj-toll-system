namespace Business.Interfaces;

public interface IFeeService
{
	public Task<List<TollPassageData>> ApplyFeeToAllPassages(List<TollPassageData> tollPassageData);

	public Task<List<VehicleDailyFee>> SaveDailyFeeSummaryForEachVehicle(List<TollPassageData> passageData);

	public decimal GetMaxDailyFee();
}

namespace Business.Interfaces;

public interface IFeeService
{
	public Task<List<VehicleDailyFee>> GetDailyFeeSummaryForEachVehicle(List<TollPassageData> tollPassages);
	public decimal GetMaxDailyFee();

}
namespace Business.Interfaces;

public interface IFeeService
{
	public Task<List<VehicleDailyFee>> GetDailyFeeSummaryForEachVehicle(List<TollPassage> tollPassages);
	public decimal GetMaxDailyFee();

}
namespace Business.Interfaces;

public interface IFeeService
{
	public Task<List<VehicleDailyFee>> GetDailyFeeSummaryForEachVehicle(List<TollCameraData> tollPassages);
	public decimal GetMaxDailyFee();
	public Task<List<TollPassageData>> ApplyFeeToAllPassages(List<TollPassageData> tollPassageData);

}
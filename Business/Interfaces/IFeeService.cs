namespace Business.Interfaces;

public interface IFeeService
{
	public Task<VehicleDailyFee> GetTotalFeeForVehiclePassages(List<TollPassage> tollPassages);

}
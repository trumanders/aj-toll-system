namespace Business.Models;

public class ProcessedPassages
{
	public List<TollPassageData> TollCameraData{ get; set; }
	public List<VehicleDailyFee> VehiclesDailyFees { get; set; }
	public List<MonthlyFeeDTO> MonthlyFees { get; set; }

}

namespace Business.Models;

public class ProcessedTollData
{
	public List<TollPassage> TollPassages { get; set; }
	public List<VehicleDailyFee> VehiclesDailyFees { get; set; }
	public List<MonthlyFeeDTO> MonthlyFees { get; set; }

}

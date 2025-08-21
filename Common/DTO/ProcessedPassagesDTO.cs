namespace Business.Models;

public class ProcessedPassagesDTO
{
	public string PlateNumber { get; set; }
	public string? VehicleTypeName { get; set; }
	public decimal DailyFee { get; set; }
	public decimal AccumulatedFee { get; set; }
	public DateTime MostRecentFeeDate { get; set; }
}

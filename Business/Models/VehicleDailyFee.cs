namespace Business.Models;

public class VehicleDailyFee
{
	public string PlateNumber { get; set; }
	public decimal? DailyFee { get; set; }
	public DateTime Date { get; set; }
}

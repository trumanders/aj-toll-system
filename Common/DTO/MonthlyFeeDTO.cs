namespace Common.DTO;

public class MonthlyFeeDTO
{
	public int Id { get; set; }
	public string? PlateNumber { get; set; }
	public decimal AccumulatedFee { get; set; }
	public DateTime Date { get; set; }
}

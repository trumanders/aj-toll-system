namespace Common.DTO;

public class BillingDTO
{
	public string PlateNumber { get; set; }

	public string? OwnerName { get; set; }

	public DateTime Date { get; set; }

	public decimal AccumulatedFee { get; set; }
}

namespace Persistence.Entities;

public class DailyFee : IEntity
{
	[Key]
	public int Id { get; set; }

	[StringLength(6, MinimumLength = 6), Required]
	public string? PlateNumber { get; set; }
	
	[Required]
	public decimal TotalDailyFee { get; set; }

	[Required]
	public DateTime Date { get; set; }
}

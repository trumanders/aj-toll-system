namespace Persistence.Entities;

public class MonthlyFee : IEntity
{
	[Key]
	public int Id { get; set; }

	[StringLength(6, MinimumLength = 6), Required]
	public string? PlateNumber { get; set; }

	[Required]
	public decimal TotalMonthlyFee { get; set; }

	[Required]
	public int Month { get; set; }
}

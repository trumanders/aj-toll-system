namespace Persistence.Entities;

public class MonthlyFee : IEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string PlateNumber { get; set; }

	[Required]
	public decimal AccumulatedFee { get; set; }

	[Required]
	public int Year { get; set; }

	[Required]
	public int Month { get; set; }
}


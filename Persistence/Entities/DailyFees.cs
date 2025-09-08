namespace Persistence.Entities;

public class DailyFees : IEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string PlateNumber { get; set; }

	[Required]
	public DateTime Date { get; set; }

	[Required]
	public decimal DailyFee { get; set; }
}


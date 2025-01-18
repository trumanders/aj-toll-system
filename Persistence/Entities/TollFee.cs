namespace Persistence.Entities;

public class TollFee : IEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public decimal Fee { get; set; }

	public List<TollFeeTimeInterval>? TollFeeTimeIntervals { get; set; }
}

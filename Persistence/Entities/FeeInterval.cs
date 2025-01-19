namespace Persistence.Entities;

public class FeeInterval : IEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public decimal Fee { get; set; }

	[Required]
	public TimeSpan Start { get; set; }

	[Required]
	public TimeSpan End { get; set; }


}

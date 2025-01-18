namespace Persistence.Entities;  

public class TollPassage : IEntity
{
	[Key]
	public int Id { get; set; }

	[StringLength(6, MinimumLength = 6), Required]
	public string? PlateNumber { get; set; }

	[Required]
	public DateTime PassageTime { get; set; }
}

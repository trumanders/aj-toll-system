using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class Billing : IEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string? PlateNumber { get; set; }

	[Required]
	public string? OwnerName { get; set; }
	public decimal AccumulatedFee { get; set; }
}

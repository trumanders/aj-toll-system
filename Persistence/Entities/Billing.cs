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

	[Required]
	public int VehicleTypeId { get; set; }

	[ForeignKey("VehicleTypeId")]
	public virtual VehicleType? VehicleType { get; set; }

	[Required]
	public DateTime Date { get; set; }

	[Required]
	public decimal AccumulatedFee { get; set; }
}

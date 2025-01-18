namespace Persistence.Entities;

/**
 * Simulating extrnal vehicle API data to retrieve vehicle information from
 */

public class VehicleInfo : IEntity
{
	[Key]
	public int Id { get; set; }

	[StringLength(6, MinimumLength = 6), Required]
	public string PlateNumber { get; set; } = string.Empty;

	[MaxLength(50), Required]
	public string OwnerName { get; set; } = string.Empty;

	[Required]
	public int VehicleTypeId { get; set; }

	[Required]
	public virtual VehicleType? VehicleType { get; set; }
}

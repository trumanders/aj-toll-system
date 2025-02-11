namespace Persistence.Entities;

/**
 * Simulating extrnal vehicle API data to retrieve vehicle information from
 */

public class VehicleInfo : IEntity
{
	[Key]
	public int Id { get; set; }

	[StringLength(6, MinimumLength = 6), Required]
	public string PlateNumber { get; set; }

	[MaxLength(50), Required]
	public string OwnerName { get; set; }

	[Required]
	public int VehicleTypeId { get; set; }

	public VehicleType? VehicleType { get; set; }
}

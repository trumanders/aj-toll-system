namespace Persistence.Entities;

/**
 * Simulates external vehicle API data
 */

public class SimulatedVehicleApiData : IEntity
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


LÄGG IN VEHICLE TYPE I SIMULATED VEHICLE API DATA-TABELLEN / ENTITETEN!! INTE HURUVIDA TYPEN ÄR TOLL FREE.DET ÄR VÅR EGEN LOGIK!!
namespace Persistence.Entities;

public class VehicleOwner : IEntity
{
	[Key]
	public int Id { get; set; }

	[MaxLength(50), Required]
	public string? VechicleOwnerName { get; set; }

	[Required]
	public virtual ICollection<Vehicle>? Vehicles { get; set; }
}

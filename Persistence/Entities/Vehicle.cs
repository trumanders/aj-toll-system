using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class Vehicle : IEntity
{
	[Key]
	public int Id { get; set; }

	[MaxLength(50), Required]
	public string? VehicleName { get; set; }

	[Required]
	public int VehicleOwnerId { get; set; }

	[ForeignKey("VehicleOwnerId"), Required]
	public virtual VehicleOwner? VehicleOwner { get; set; }



	[Required]
	public virtual ICollection<VehicleType> VehicleTypes { get; set; } = new HashSet<VehicleType>();
	public virtual ICollection<TollPassage> TollPassages { get; set; } = new List<TollPassage>();
}

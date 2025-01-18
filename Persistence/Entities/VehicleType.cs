namespace Persistence.Entities;

public class VehicleType : IEntity
{
	[Key]
	public int Id { get; set; }

	[MaxLength(50), Required]
	public string TypeName { get; set; }
}

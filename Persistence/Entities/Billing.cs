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
	public decimal TotalMonthlyFee { get; set; }

	public virtual VehicleInfo? VehicleInfo { get; set; }
}

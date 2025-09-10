namespace Persistence.Entities;

public class Billing : IEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string PlateNumber { get; set; }

	[Required]
	public decimal AccumulatedFee { get; set; }

	[Required]
	public string OwnerName { get; set; }

	[MaxLength(50), Required]
	public string OwnerStreetName { get; set; }

	[MaxLength(6), Required]
	public string OwnerZipCode { get; set; }

	[MaxLength(20), Required]
	public string OwnerCity { get; set; }

	[MaxLength(20), Required]
	public string OwnerCountry { get; set; }
}

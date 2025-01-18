using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace Persistence.Entities;  

public class TollPassage : IEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public DateTime PassageTime { get; set; }

	public int TollFeeId { get; set; }

	[ForeignKey("TollFeeId")]
	public virtual TollFee? TollFee { get; set; }

	public int VehcielId { get; set; }

	[ForeignKey("VehicleId")]
	public Vehicle? Vehicle { get; set; }

}

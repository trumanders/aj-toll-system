using System.ComponentModel.DataAnnotations.Schema;
namespace Persistence.Entities;

public class TollFeeTimeInterval : IEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public TimeSpan StartTime { get; set; }

	[Required]
	public TimeSpan EndTime { get; set; }

	public int TollFeeId { get; set; }

	[ForeignKey("TollFeeId")]
	public virtual TollFee? TollFee { get; set; }
}

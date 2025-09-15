namespace Business.Models;

public class FeeIntervalModel : IBusinessModel
{
	public decimal Fee { get; set; }
	public TimeSpan Start { get; set; }
	public TimeSpan End { get; set; }
}

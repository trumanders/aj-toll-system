namespace Business.Models;

public class TollCameraData
{
	public string PlateNumber { get; set; }
	public DateTime PassageTime { get; set; }
	public decimal Fee { get; set; } = 0;
}

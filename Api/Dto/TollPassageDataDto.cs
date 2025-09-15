namespace Api.Dto;

public class TollPassageDataDto
{
	public string PlateNumber { get; set; }
	public DateTime PassageTime { get; set; }
	public decimal? Fee { get; set; }
}

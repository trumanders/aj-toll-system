namespace Business.Models;

<<<<<<<< HEAD:Business/Models/TollPassageData.cs
public class TollPassageData
========
public class TollCameraData
>>>>>>>> develop:Business/Models/TollCameraData.cs
{
	public string PlateNumber { get; set; }
	public DateTime PassageTime { get; set; }
	public decimal Fee { get; set; } = 0;
}

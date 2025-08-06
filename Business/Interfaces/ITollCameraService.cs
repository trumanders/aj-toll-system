namespace Business.Interfaces;

public interface ITollCameraService
{
	public Task<List<TollPassageData>> SimulateDailyTollCameraData(DateTime date, int numberOfPassages);
	
}

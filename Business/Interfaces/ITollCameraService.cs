namespace Business.Interfaces;

public interface ITollCameraService
{
	public Task<List<TollCameraData>> SimulateDailyTollCameraData(DateTime date, int numberOfPassages);	
}

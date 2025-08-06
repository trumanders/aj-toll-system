namespace Business.Interfaces;

public interface ITollCameraService
{
	public Task<List<TollCameraData>> GenerateDailyTollCameraData(DateTime date, int numberOfPassages);
	
}

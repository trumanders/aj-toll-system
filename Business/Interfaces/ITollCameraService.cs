namespace Business.Interfaces;

public interface ITollCameraService
{
	public Task<List<TollCameraData>> GetDailyTollCameraData(DateTime date, int numberOfPassages);
}

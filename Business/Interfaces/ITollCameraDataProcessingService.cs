namespace Business.Interfaces;

public interface ITollCameraDataProcessingService
{
	public Task<List<MonthlyFeeDTO>> ProcessDailyTollCameraData(DateTime date, int numberOfTollPassages);
}

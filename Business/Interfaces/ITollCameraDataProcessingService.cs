namespace Business.Interfaces;

public interface ITollCameraDataProcessingService
{
	public Task<ProcessedPassages> ProcessDailyTollCameraData(DateTime date, int numberOfTollPassages);
}

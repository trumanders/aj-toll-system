namespace Business.Interfaces;

public interface ITollDataProcessingService
{
	public Task<ProcessedTollData> ProcessDailyTollData(DateTime date, int numberOfTollPassages);
}

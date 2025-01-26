namespace Business.Interfaces;

public interface ITollPassageService
{
	public Task<List<TollPassageNoFee>> GenerateTollPassagesForOneDay(DateTime date, int numberOfPassages);
	public Task<List<VehicleDailyFee>> GetDailyFeeSummaryForEachVehicle(List<TollPassage> tollPassages);
}

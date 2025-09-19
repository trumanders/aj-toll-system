namespace Business.Interfaces
{
	public interface ITollPassageDataProcessingService
	{
		Task<List<VehicleDailyFee>> ProcessDailyTollCameraData(DateTime date, int numberOfPassages);
	}
}
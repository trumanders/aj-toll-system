namespace Business.Interfaces
{
	public interface ITollCameraDataProcessingService
	{
		Task<List<VehicleDailyFee>> ProcessDailyTollCameraData(DateTime date, int numberOfPassages);
	}
}
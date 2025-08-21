namespace Business.Interfaces
{
	public interface IPassagesService
	{
		Task<List<MonthlyFeeDTO>> ProcessDailyTollCameraData(DateTime date, int numberOfTollPassages);
		Task<List<TollCameraDataWithVehicleTypeDTO>> AddVehicleTypeToTollCameraDataAsync(List<TollCameraData> tollCameraDataToFilter);
		Task<List<TollCameraDataWithVehicleTypeDTO>> FilterOutTollFreeVehicles(List<TollCameraDataWithVehicleTypeDTO> tollCameraDataWithVehicleType);
	}
}
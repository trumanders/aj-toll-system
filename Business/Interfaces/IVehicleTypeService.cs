namespace Business.Interfaces;

public interface IVehicleTypeService
{
	public Task<List<TollPassageData>> AddVehicleTypeToTollCameraDataAsync(List<TollPassageData> tollCameraDataToFilter);

	public Task<List<TollPassageData>> FilterOutTollFreeVehiclesAsync(List<TollPassageData> tollCameraDataWithVehicleType);
}

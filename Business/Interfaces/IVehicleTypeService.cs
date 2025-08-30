namespace Business.Interfaces;

public interface IVehicleTypeService
{
	public Task<List<TollCameraDataWithVehicleTypeDTO>> AddVehicleTypeToTollCameraDataAsync(List<TollCameraData> tollCameraDataToFilter);

	public Task<List<TollCameraDataWithVehicleTypeDTO>> FilterOutTollFreeVehiclesAsync(List<TollCameraDataWithVehicleTypeDTO> tollCameraDataWithVehicleType);

}

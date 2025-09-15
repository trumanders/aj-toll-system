namespace Business.Interfaces;

public interface IVehicleTypeService
{
	public Task<List<TollPassageData>> FilterOutTollFreeVehiclesAsync(List<TollCameraData> tollPassageData);
}

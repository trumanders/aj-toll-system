namespace Business.Services;

public class VehicleTypeService(IDbService _dbService) : IVehicleTypeService
{
	public async Task<List<TollPassageData>> AddVehicleTypeToTollCameraDataAsync(List<TollPassageData> tollCameraDataToFilter)
	{
		var apiDataPlateAndType = await _dbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateAndType>(data =>
			tollCameraDataToFilter.Select(x => x.PlateNumber).Contains(data.PlateNumber));

		var tollPassageDataWithType = apiDataPlateAndType
				.Join(tollCameraDataToFilter,
					plateAndType => plateAndType.PlateNumber,
					dataToFilter => dataToFilter.PlateNumber,
					(plateAndType, dataToFilter) => new TollPassageData()
					{
						PlateNumber = plateAndType.PlateNumber,
						VehicleTypeName = plateAndType.VehicleTypeName,
						PassageTime = dataToFilter.PassageTime
					});

		return [.. tollPassageDataWithType];
	}

	public async Task<List<TollPassageData>> FilterOutTollFreeVehiclesAsync(List<TollPassageData> tollCameraDataWithVehicleType)
	{
		if (tollCameraDataWithVehicleType.Any(x => x.VehicleTypeName is null))
			throw new ArgumentException("VehicleType is required. Please include vehicle type in the request.");

		var tollFreeVehicles = await _dbService.GetAsync<VehicleType, VehicleTypeDTO>(x => x.IsTollFree);
		var nonTollFreeVehiclesCameraDataWithType = tollCameraDataWithVehicleType
			.Where(x => !tollFreeVehicles.Select(v => v.VehicleTypeName).Contains(x.VehicleTypeName))
			.ToList();

		return nonTollFreeVehiclesCameraDataWithType;
	}
}
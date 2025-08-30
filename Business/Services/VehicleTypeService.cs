namespace Business.Services;

public class VehicleTypeService(IDbService _dbService) : IVehicleTypeService
{
	public async Task<List<TollCameraDataWithVehicleTypeDTO>> AddVehicleTypeToTollCameraDataAsync(List<TollCameraData> tollCameraDataToFilter)
	{
		var apiDataPlateAndType = await _dbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateAndType>(data =>
			tollCameraDataToFilter.Select(x => x.PlateNumber).Contains(data.PlateNumber));

		var tollCameraDataWithType = apiDataPlateAndType
				.Join(tollCameraDataToFilter,
					plateAndType => plateAndType.PlateNumber,
					dataToFilter => dataToFilter.PlateNumber,
					(plateAndType, dataToFilter) => new TollCameraDataWithVehicleTypeDTO()
					{
						PlateNumber = plateAndType.PlateNumber,
						VehicleTypeName = plateAndType.VehicleTypeName,
						PassageTime = dataToFilter.PassageTime
					});


		return [.. tollCameraDataWithType];
	}

	public async Task<List<TollCameraDataWithVehicleTypeDTO>> FilterOutTollFreeVehiclesAsync(List<TollCameraDataWithVehicleTypeDTO> tollCameraDataWithVehicleType)
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
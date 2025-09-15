namespace Business.Services;

public class VehicleTypeService(IDbService _dbService) : IVehicleTypeService
{
	public async Task<List<TollPassageData>> FilterOutTollFreeVehiclesAsync(List<TollCameraData> tollCameraData)
	{
		var plateNumberWithType = await _dbService
			.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataPlateAndType>(data =>
				tollCameraData.Select(x => x.PlateNumber).Contains(data.PlateNumber)
			);

		var tollFreeVehicleTypeNames = (await _dbService.GetAsync<VehicleType, VehicleTypeModel>(x => x.IsTollFree))
			.Select(x => x.VehicleTypeName);

		var nonTollFreeVehiclesPassageData = tollCameraData.Join(
				plateNumberWithType,
				tollCameraData => tollCameraData.PlateNumber,
				plateAndType => plateAndType.PlateNumber,
				(tollCameraData, plateAndType) => new { TollPassage = tollCameraData, plateAndType.VehicleTypeName }
			)
			.Where(x => !tollFreeVehicleTypeNames.Contains(x.VehicleTypeName))
			.Select(x => new TollPassageData
			{
				PlateNumber = x.TollPassage.PlateNumber,
				PassageTime = x.TollPassage.PassageTime
			})
			.ToList();

		return nonTollFreeVehiclesPassageData;
	}
}

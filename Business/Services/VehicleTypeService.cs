namespace Business.Services;

public class VehicleTypeService(IDbService _dbService) : IVehicleTypeService
{
	public async Task<List<TollPassageData>> FilterOutTollFreeVehiclesAsync(List<TollPassageData> tollPassageData)
	{
		var plateNumberWithType = await _dbService
			.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateAndType>(data => tollPassageData.Select(x => x.PlateNumber).Contains(data.PlateNumber));

		var tollFreeVehicleTypeNames = (await _dbService.GetAsync<VehicleType, VehicleTypeDTO>(x => x.IsTollFree))
			.Select(x => x.VehicleTypeName);

		var nonTollFreeVehiclesPassageData = tollPassageData
			.Join(
				plateNumberWithType,
				tollPassage => tollPassage.PlateNumber,
				plateAndType => plateAndType.PlateNumber,
				(tollPassage, plateAndType) =>
					new { TollPassage = tollPassage, plateAndType.VehicleTypeName }
			)
			.Where(x => !tollFreeVehicleTypeNames.Contains(x.VehicleTypeName))
			.Select(x => x.TollPassage)
			.ToList();

		return nonTollFreeVehiclesPassageData;
	}
}

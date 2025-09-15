namespace Business.Services;

public class TollPassageDataProcessingService(ITollCameraService _tollCameraService, IVehicleTypeService _vehicleTypeService, IFeeService _feeService)
{
	public async Task ProcessDailyTollCameraData(DateTime date, int numberOfPassages)
	{
		// Get raw toll camera data
		var tollCameraData = await _tollCameraService.GetDailyTollCameraData(date, numberOfPassages);

		// Filter out toll free types
		var tollPassageData = await _vehicleTypeService.FilterOutTollFreeVehiclesAsync(tollCameraData);

		// Apply fees
		var tollPassageDataWithFees = await _feeService.ApplyFeeToAllPassages(tollPassageData);

		// Save daily fees per vehicle
		var savedDailyFeesPerVehicle = await _feeService.SaveDailyFeeSummaryForEachVehicle(tollPassageDataWithFees);



	}

	private List<TollPassageData> MapToTollPassageData(List<TollCameraData> rawCameraData)
	{
		List<TollPassageData> tollPassageData = [];

		foreach (var cameraData in rawCameraData)
		{
			tollPassageData.Add(
				new TollPassageData()
				{
					PlateNumber = cameraData.PlateNumber,
					PassageTime = cameraData.PassageTime,
				}
			);
		}
		return tollPassageData;
	}
}

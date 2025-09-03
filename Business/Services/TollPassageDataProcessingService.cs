namespace Business.Services;

public class TollPassageDataProcessingService(
	ITollCameraService _tollCameraService,
	IVehicleTypeService _vehicleTypeService,
	IFeeService _feeService)
{
	public async Task ProcessDailyTollCameraData(DateTime date, int numberOfPassages)
	{
		// Get raw toll camera data
		var tollPassageData = MapToTollPassageData(await _tollCameraService.GetDailyTollCameraData(date, numberOfPassages));
		
		// Apply vehicle types
		var tollCameraDataWithType = await _vehicleTypeService.AddVehicleTypeToTollCameraDataAsync(tollPassageData);

		// Filter out toll free types
		var tollCameraDataWithoutTollFreeVehicles = await _vehicleTypeService.FilterOutTollFreeVehiclesAsync(tollCameraDataWithType);

		// Apply fees
		var tollPassageDataWithFees = await _feeService.ApplyFeeToAllPassages(tollCameraDataWithoutTollFreeVehicles);

		// Summarize daily fees per vehicle
		var vehiclesWithDailyFees = _feeService.GetDailyFeeSummaryForEachVehicle(tollPassageDataWithFees);

		// Write to database MonthlyFee-table: Add vehicles+dailyfee to the table, accumulating monthly fee

	}

	private List<TollPassageData> MapToTollPassageData(List<TollCameraData> rawCameraData)
	{
		List<TollPassageData> tollPassageData = [];

		foreach (var cameraData in rawCameraData)
		{
			tollPassageData.Add(new TollPassageData()
			{
				PlateNumber = cameraData.PlateNumber,
				PassageTime = cameraData.PassageTime,
			});
		}
		return tollPassageData;
	}
}

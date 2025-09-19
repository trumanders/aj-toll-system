namespace Business.Services;

public class TollCameraDataProcessingService(
	ITollCameraService _tollCameraService,
	IVehicleTypeService _vehicleTypeService,
	IFeeService _feeService) : ITollCameraDataProcessingService
{
	public async Task<List<VehicleDailyFee>> ProcessDailyTollCameraData(DateTime date, int numberOfPassages)
	{
		// Get raw toll camera data
		var tollCameraData = await _tollCameraService.GetDailyTollCameraData(date, numberOfPassages);

		// Filter out toll free types
		var tollPassageData = await _vehicleTypeService.FilterOutTollFreeVehiclesAsync(tollCameraData);

		// Apply fees
		var tollPassageDataWithFees = await _feeService.ApplyFeeToAllPassages(tollPassageData);

		// Save daily fees per vehicle
		var savedDailyFeesPerVehicle = await _feeService.SaveDailyFeeSummaryForEachVehicle(tollPassageDataWithFees);

		return savedDailyFeesPerVehicle;
	}
}

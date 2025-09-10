namespace Business.Services;

public class TollCameraService : ITollCameraService
{
	private readonly IDbService _dbService;

	private const int secondsWithinOneDay = 24 * 60 * 60;

	public TollCameraService(IDbService dbService)
	{
		_dbService = dbService;
	}

	// Simulates the camera scanning of plate numbers and times
	public async Task<List<TollCameraData>> GetDailyTollCameraData(DateTime date, int numberOfPassages)
	{
		// The simulated scanning of plate numbers must be based on the existing plate numbers in the simulated vehicle API data.
		var simulatedPlateNumberScans = await _dbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateNumber>();
		var tollCameraData = new List<TollCameraData>();
		if (simulatedPlateNumberScans.Count == 0)
		{
			return tollCameraData;
		}
		var random = new Random();

		for (int i = 0; i < numberOfPassages; i++)
		{
			tollCameraData.Add(
				new TollCameraData()
				{
					PlateNumber = simulatedPlateNumberScans[random.Next(0, simulatedPlateNumberScans.Count)].PlateNumber,
					PassageTime = date.AddSeconds(random.Next(0, secondsWithinOneDay)),
				}
			);
		}

		return [.. tollCameraData.OrderBy(x => x.PassageTime)];
	}
}

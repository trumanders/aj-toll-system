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
	public async Task<List<TollCameraData>> GenerateDailyTollCameraData(DateTime date, int numberOfPassages)
	{
		// This step is to make sure that the generated passages have plate numbers that we have access to. (simulate external vehicle info database)
		var plateNumbers = await _dbService.GetAsync<Persistence.Entities.SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateNumber>();

		if (plateNumbers.Count == 0) { return new List<TollCameraData>(); }

		var tollPassages = new List<TollCameraData>();
		var random = new Random();

		for (int i = 0; i < numberOfPassages; i++)
		{
			tollPassages.Add(new TollCameraData
			{
				PlateNumber = plateNumbers[random.Next(0, plateNumbers.Count)].PlateNumber,
				PassageTime = date.AddSeconds(random.Next(0, secondsWithinOneDay))
			});
		}
		
		return tollPassages.OrderBy(x => x.PassageTime).ToList();
	}
}
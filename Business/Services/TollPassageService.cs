namespace Business.Services;

public class TollPassageService : ITollPassageService
{
	private readonly IDbService _dbService;
	private const int secondsWithinOneDay = 86399;
	public TollPassageService(IDbService dbService)
	{
		_dbService = dbService;
	}

	public async Task<List<TollPassage>> GenerateTollPassagesForOneDay(DateTime date, int numberOfPassages)
	{
		var plateNumbers = await _dbService.GetAsync<VehicleInfo, VehicleInfoDTOPlateNumber>();
		var tollPassages = new List<TollPassage>();
		var random = new Random();

		// Generate specified number of passages
		// and randomize plate numbers and passage datetimes within the 
		// specified date
		for (int i = 0; i < numberOfPassages; i++)
		{
			tollPassages.Add(new TollPassage
			{
				PlateNumber = plateNumbers[random.Next(0, plateNumbers.Count)].PlateNumber,
				PassageTime = date.AddSeconds(random.Next(0, secondsWithinOneDay))
			});
		}
		
		return tollPassages.OrderBy(x => x.PassageTime).ToList();
	}
}
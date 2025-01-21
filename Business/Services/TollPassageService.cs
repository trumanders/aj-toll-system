namespace Business.Services;

public class TollPassageService : ITollPassageService
{
	private readonly IDbService _dbService;

	public TollPassageService(IDbService dbService)
	{
		_dbService = dbService;
	}

	public async Task<List<TollPassage>> GenerateTollPassages(DateTime date, int numberOfPassages)
	{
		var plateNumbers = await _dbService.GetAsync<VehicleInfo, VehicleInfoDTOPlateNumber>();
		var tollPassages = new List<TollPassage>();
		var random = new Random();
		var minutesWithinDay = (60 * 24) - 1;

		// Generate specified number of passages
		// and randomize plate numbers and passage datetimes within the 
		// specified date
		for (int i = 0; i < numberOfPassages; i++)
		{
			tollPassages.Add(new TollPassage
			{
				PlateNumber = plateNumbers[random.Next(0, plateNumbers.Count)].PlateNumber,
				PassageDate = date.AddMinutes(random.Next(0, minutesWithinDay))
			});
		}
		
		return tollPassages.OrderBy(x => x.PassageDate).ToList();
	}
}
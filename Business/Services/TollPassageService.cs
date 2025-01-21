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

		foreach (var plateNumber in plateNumbers)
		{
			var random = new Random();
			var tollPassage = new TollPassage
			{
				PlateNumber = plateNumber.PlateNumber,
				PassageDate = date.AddMinutes(random.Next(0, 60 * 24))
			};
			tollPassages.Add(tollPassage);
		}
		return tollPassages;
	}
}
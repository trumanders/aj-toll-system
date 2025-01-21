namespace Business.Interfaces;

public interface ITollPassageService
{
	public Task<List<TollPassage>> GenerateTollPassages(DateTime date, int numberOfPassages);

}

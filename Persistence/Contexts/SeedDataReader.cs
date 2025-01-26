
namespace Persistence.Contexts;

public static class SeedDataReader
{
	private static readonly string _jsonFilePath = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), "seedData.json");

	public static SeedData GetSeedData()
	{
		using StreamReader reader = new StreamReader(_jsonFilePath);
		var json = reader.ReadToEnd();
		var seedData = JsonConvert.DeserializeObject<SeedData>(json);

		return seedData;
	}
}
  
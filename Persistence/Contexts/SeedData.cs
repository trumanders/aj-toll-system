namespace Persistence.Contexts;

public class SeedData
{
	public List<FeeIntervalSeedData> FeeIntervals { get; set; }
	public List<VehicleInfoSeedData> VehicleInfo { get; set; }
	public List<VehicleTypeSeedData> VehicleTypes { get; set; }

	public List<int> TollFreeMonths { get; set; }
	public int DefaultFee { get; set; }
}

public class FeeIntervalSeedData
{
	public int Fee { get; set; }
	public TimeSpan Start { get; set; }
	public TimeSpan End { get; set; }
}

public class VehicleInfoSeedData
{
	public string PlateNumber { get; set; }
	public string OwnerName { get; set; }
	public int VehicleTypeId { get; set; }
}

public class VehicleTypeSeedData
{
	public int Id { get; set; }
	public string TypeName { get; set; }
	public bool IsTollFree { get; set; }
}

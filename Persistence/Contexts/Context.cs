
namespace Persistence.Contexts;

public class Context : DbContext
{
	public Context(DbContextOptions<Context> options) : base(options) { }

	public DbSet<Billing> Billings => Set<Billing>();
	public DbSet<DailyFee> DailyFees => Set<DailyFee>();
	public DbSet<MonthlyFee> MonthlyFees => Set<MonthlyFee>();
	public DbSet<TollFee> TollFees => Set<TollFee>();
	public DbSet<TollFeeTimeInterval> TollFeesTimeIntervals => Set<TollFeeTimeInterval>();
	public DbSet<TollPassage> TollPassages => Set<TollPassage>();
	public DbSet<Vehicle> Vehicles => Set<Vehicle>();
	public DbSet<VehicleInfo> VehicleInfo => Set<VehicleInfo>();
	public DbSet<VehicleOwner> VehicleOwners => Set<VehicleOwner>();
	public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// Disable cascade delete here

		// Configure composite keys here (many to many)
	}
}

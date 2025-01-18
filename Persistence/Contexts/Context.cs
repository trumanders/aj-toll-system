
namespace Persistence.Contexts;

public class Context : DbContext
{
	public Context(DbContextOptions<Context> options) : base(options) { }
	public DbSet<TollFee> TollFees { get; set; }
	public DbSet<TollFeeTimeInterval> TollFeesTimeIntervals { get; set; }
	public DbSet<TollPassage> TollPassages { get; set; }
	public DbSet<Vehicle> Vehicles { get; set; }
	public DbSet<VehicleType> VehicleTypes { get; set; }
	public DbSet<VehicleOwner> VehicleOwners{ get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// Disable cascade delete here

		// Configure composite keys here (many to many)
	}
}

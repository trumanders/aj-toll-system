namespace Persistence.Contexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
	public DbSet<Billing> Billing => Set<Billing>();
	public DbSet<FeeInterval> FeeInterval => Set<FeeInterval>();
	public DbSet<SimulatedVehicleApiData> SimulatedVehicleApiData => Set<SimulatedVehicleApiData>();
	public DbSet<VehicleType> VehicleType => Set<VehicleType>();
	public DbSet<DailyFees> DailyFees => Set<DailyFees>();

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

		base.OnModelCreating(builder);

		builder.Entity<DailyFees>()
			.HasIndex(d => new { d.Date, d.PlateNumber })
			.IsUnique();

		// Disable cascade delete here

		// Configure composite keys here (many to many)
	}
}

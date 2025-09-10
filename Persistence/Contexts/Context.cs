namespace Persistence.Contexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
	public DbSet<Billing> Billing => Set<Billing>();
	public DbSet<FeeInterval> FeeInterval => Set<FeeInterval>();
	public DbSet<SimulatedVehicleApiData> SimulatedVehicleApiData => Set<SimulatedVehicleApiData>();
	public DbSet<VehicleType> VehicleType => Set<VehicleType>();

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

		base.OnModelCreating(builder);

		// Disable cascade delete here

		// Configure composite keys here (many to many)
	}
}

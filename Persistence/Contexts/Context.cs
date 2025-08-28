	namespace Persistence.Contexts;
	public class Context : DbContext
	{
		public DbSet<Billing> Billing => Set<Billing>();
		public DbSet<FeeInterval> FeeInterval => Set<FeeInterval>();
		public DbSet<MonthlyFee> MonthlyFee => Set<MonthlyFee>();
		public DbSet<SimulatedVehicleApiData> SimulatedVehicleApiData => Set<SimulatedVehicleApiData>();
		public DbSet<VehicleType> VehicleType => Set<VehicleType>();

		public Context(DbContextOptions<Context> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Disable cascade delete here

			// Configure composite keys here (many to many)
		}
	}

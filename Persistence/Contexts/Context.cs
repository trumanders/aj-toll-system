	namespace Persistence.Contexts;
	public class Context : DbContext
	{
		public DbSet<Billing> Billing => Set<Billing>();
		public DbSet<FeeInterval> FeeInterval => Set<FeeInterval>();
		public DbSet<MonthlyFee> MonthlyFee => Set<MonthlyFee>();
		public DbSet<VehicleInfo> VehicleInfo => Set<VehicleInfo>();
		public DbSet<VehicleType> VehicleType => Set<VehicleType>();

		public Context(DbContextOptions<Context> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Disable cascade delete here

			// Configure composite keys here (many to many)

			// Seed data here

			SeedData(builder);
		}

		private void SeedData(ModelBuilder builder)
		{
			var seedData = SeedDataReader.GetSeedData();
			SeedFeeIntervalData(builder, ref seedData);
			SeedVehicleTypeData(builder, ref seedData);
			SeedVehicleInfoData(builder, ref seedData);
		}

		#region SeedData
		private void SeedFeeIntervalData(ModelBuilder builder, ref SeedData seedData)
		{		
			var feeIntervals = new List<FeeInterval>();
			int id = 1;
			foreach (var feeInterval in seedData.FeeIntervals)
			{
				feeIntervals.Add(new FeeInterval
				{
					Id = id,
					Fee = feeInterval.Fee,
					Start = feeInterval.Start,
					End = feeInterval.End
				});
				id++;
			}
			builder.Entity<FeeInterval>().HasData(feeIntervals);
		}

		private void SeedVehicleTypeData(ModelBuilder builder, ref SeedData seedData)
		{
			var vehicleTypes = new List<VehicleType>();
			foreach (var vehicleType in seedData.VehicleTypes)
			{
				vehicleTypes.Add(new VehicleType
				{
					Id = vehicleType.Id,
					TypeName = vehicleType.TypeName,
					IsTollFree = vehicleType.IsTollFree
				});
			}
			builder.Entity<VehicleType>().HasData(vehicleTypes);

		}

		private void SeedVehicleInfoData(ModelBuilder builder, ref SeedData seedData)
		{
			var vehicleInfos = new List<VehicleInfo>();

			int id = 1;
			foreach (var vehicleInfo in seedData.VehicleInfo)
			{
				vehicleInfos.Add(new VehicleInfo
				{
					Id = id,
					PlateNumber = vehicleInfo.PlateNumber,
					OwnerName = vehicleInfo.OwnerName,
					VehicleTypeId = vehicleInfo.VehicleTypeId
				});
				id++;
			}
			builder.Entity<VehicleInfo>().HasData(vehicleInfos);
		}
		#endregion
	}

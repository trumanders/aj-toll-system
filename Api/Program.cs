namespace Api;
public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		try
		{
			var dbConnection = builder.Configuration.GetConnectionString("SqlConnection");
			builder.Services.AddDbContext<Context>(options =>
				options.UseSqlServer(dbConnection));
		}
		catch (Exception ex)
		{
			// Log the error here for debugging
			Console.WriteLine("Database connection error: " + ex.Message);
		}

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.AddScoped<IDbService, DbService>();
		builder.Services.AddScoped<IFeeService, FeeService>();
		builder.Services.AddScoped<IPublicHolidays, SwedenPublicHoliday>();
		builder.Services.AddScoped<ITollFreeDaysService, TollFreeDaysService>();
		builder.Services.AddScoped<ITollPassageService, TollPassageService>();

		// Register Context
		builder.Services.AddDbContext<Context>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
		);

		// Register AutoMapper
		builder.Services.AddSingleton(new MapperConfiguration(config =>
		{
			// GET VehicleInfo
			
			config.CreateMap<VehicleInfo, VehicleInfoDTO>();  
			config.CreateMap<VehicleInfo, VehicleInfoDTOPlateNumber>();
		}).CreateMapper());		

		// Prevent circular references
		builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

		var app = builder.Build();

		app.UseRouting();
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
			c.RoutePrefix = string.Empty; // Swagger UI at the root
		});

		app.UseHttpsRedirection();

		//app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}

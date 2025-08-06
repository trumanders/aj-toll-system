// update-develop
namespace Api;
public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();

		builder.Services.AddDbContext<Context>(options =>
		{
			options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
		});

		builder.Services.AddLogging();

		builder.Services.AddScoped<IDbService, DbService>();
		builder.Services.AddScoped<IFeeService, FeeService>();
		builder.Services.AddScoped<IPublicHolidays, SwedenPublicHoliday>();
		builder.Services.AddScoped<ITollFreeDaysService, TollFreeDaysService>();
		builder.Services.AddScoped<ITollCameraService, TollCameraService>();
		builder.Services.AddScoped<ITollCameraDataProcessingService, TollCameraDataProcessingService>();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerDocument();

		builder.Services.AddSingleton(new MapperConfiguration(config =>
		{
			config.CreateMap<SimulatedVehicleApiData, SimulatedVehicleApiData>();  
			config.CreateMap<Persistence.Entities.SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateNumber>();
			config.CreateMap<Persistence.Entities.SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateAndType>();
			config.CreateMap<FeeInterval, FeeIntervalDTO>();
			config.CreateMap<VehicleType, VehicleTypeDTO>();
			config.CreateMap<MonthlyFee, MonthlyFeeDTO>();
			config.CreateMap<MonthlyFeeDTO, MonthlyFee>();	
		}).CreateMapper());		

		var app = builder.Build();

		app.UseRouting();
		app.UseOpenApi();
		app.UseSwaggerUi((settings) =>
		{
			settings.Path = string.Empty;
		});

		app.Use(async (context, next) =>
		{
			if (context.Request.Path == "/")
			{
				context.Response.Redirect("/swagger"); 
				return;
			}
			await next.Invoke();
		});

		//app.UseStaticFiles();
		app.UseHttpsRedirection();

		app.MapControllers();

		app.Run();
	}
}

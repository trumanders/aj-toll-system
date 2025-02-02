namespace Api;
public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Logging.AddConsole()
			.AddDebug()
			.SetMinimumLevel(LogLevel.Debug);

		builder.Services.AddControllers();
		builder.Services.AddDbContext<Context>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

		builder.Services.AddScoped<IDbService, DbService>();
		builder.Services.AddScoped<IFeeService, FeeService>();
		builder.Services.AddScoped<IPublicHolidays, SwedenPublicHoliday>();
		builder.Services.AddScoped<ITollFreeDaysService, TollFreeDaysService>();
		builder.Services.AddScoped<ITollPassageService, TollPassageService>();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerDocument();

		builder.Services.AddSingleton(new MapperConfiguration(config =>
		{
			config.CreateMap<VehicleInfo, VehicleInfoDTO>();  
			config.CreateMap<VehicleInfo, VehicleInfoDTOPlateNumber>();
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
				context.Response.Redirect("/swagger");  // Redirect to Swagger UI
				return;
			}
			await next.Invoke();
		});

		app.UseStaticFiles();
		app.UseHttpsRedirection();

		app.MapControllers();

		app.Run();
	}
}

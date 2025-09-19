using Business.Mapping;

namespace Api;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();

		builder.Services.AddDbContext<Context>(options =>
		{
			options.UseSqlServer(
				builder.Configuration.GetConnectionString("SqlConnection"),
				sqlOptions =>
					sqlOptions.EnableRetryOnFailure(
						maxRetryCount: 5,
						maxRetryDelay: TimeSpan.FromSeconds(10),
						errorNumbersToAdd: null
					)
			);
		});

		builder.Services.AddLogging();

		builder.Services.AddScoped<IDbService, DbService>();
		builder.Services.AddScoped<IPublicHolidays, SwedenPublicHoliday>();
		builder.Services.AddScoped<ITollFreeDaysService, TollFreeDaysService>();
		builder.Services.AddScoped<ITollCameraService, TollCameraService>();
		builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();
		builder.Services.AddScoped<IFeeService, FeeService>();
		builder.Services.AddScoped<ITollCameraDataProcessingService, TollCameraDataProcessingService>();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerDocument();

		builder.Services.AddAutoMapper(cfg =>
		{
			cfg.AddProfile<BusinessMappingProfile>();
			cfg.AddProfile<DtoMappingProfile>();
		});

		var app = builder.Build();

		app.UseRouting();
		app.UseOpenApi();
		app.UseSwaggerUi(
			(settings) =>
			{
				settings.Path = string.Empty;
			}
		);

		app.Use(
			async (context, next) =>
			{
				if (context.Request.Path == "/")
				{
					context.Response.Redirect("/swagger");
					return;
				}
				await next.Invoke();
			}
		);

		app.UseHttpsRedirection();

		app.MapControllers();

		app.Run();
	}
}

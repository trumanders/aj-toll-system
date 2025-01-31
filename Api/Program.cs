using Microsoft.AspNetCore.Builder;
using NSwag.AspNetCore;
namespace Api;
public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);		

		builder.Services.AddControllers();
		builder.Services.AddDbContext<Context>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
		);
		builder.Services.AddScoped<IDbService, DbService>();
		builder.Services.AddScoped<IFeeService, FeeService>();
		builder.Services.AddScoped<IPublicHolidays, SwedenPublicHoliday>();
		builder.Services.AddScoped<ITollFreeDaysService, TollFreeDaysService>();
		builder.Services.AddScoped<ITollPassageService, TollPassageService>();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerDocument();
		builder.Services.AddCors(opt =>
		{
			opt.AddPolicy(name: "CorsPolicy", builder =>
			{
				builder.WithOrigins("https://localhost:6001")
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials();
			});
		});


		// Register AutoMapper
		builder.Services.AddSingleton(new MapperConfiguration(config =>
		{
			// GET VehicleInfo
			
			config.CreateMap<VehicleInfo, VehicleInfoDTO>();  
			config.CreateMap<VehicleInfo, VehicleInfoDTOPlateNumber>();
		}).CreateMapper());		

		// Prevent circular references
		//builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

		var app = builder.Build();

		app.UseRouting();
		app.UseOpenApi();
		app.UseSwaggerUi((settings) =>
		{
			settings.Path = string.Empty;
		});

		app.UseHttpsRedirection();

		//app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}

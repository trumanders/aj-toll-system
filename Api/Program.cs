using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Api;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerDocument();

		// Register DbService
		//builder.Services.AddScoped<IDbService, DbService>();

		// Register Context
		builder.Services.AddDbContext<Context>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
		);

		// Register AutoMapper
		builder.Services.AddSingleton(new MapperConfiguration(config =>
		{
			// Map Entity - DTO here
		}).CreateMapper());

		// Prevent circular references
		builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
        {
			app.UseOpenApi();  // NSwag OpenAPI generation
			app.UseSwaggerUi();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
	/// <inheritdoc />
	public partial class updatesimulatedvehicleapi : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "OwnerCity",
				table: "SimulatedVehicleApiData",
				type: "nvarchar(20)",
				maxLength: 20,
				nullable: false,
				defaultValue: ""
			);

			migrationBuilder.AddColumn<string>(
				name: "OwnerStreetName",
				table: "SimulatedVehicleApiData",
				type: "nvarchar(50)",
				maxLength: 50,
				nullable: false,
				defaultValue: ""
			);

			migrationBuilder.AddColumn<string>(
				name: "OwnerZipCode",
				table: "SimulatedVehicleApiData",
				type: "nvarchar(6)",
				maxLength: 6,
				nullable: false,
				defaultValue: ""
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(name: "OwnerCity", table: "SimulatedVehicleApiData");

			migrationBuilder.DropColumn(name: "OwnerStreetName", table: "SimulatedVehicleApiData");

			migrationBuilder.DropColumn(name: "OwnerZipCode", table: "SimulatedVehicleApiData");
		}
	}
}

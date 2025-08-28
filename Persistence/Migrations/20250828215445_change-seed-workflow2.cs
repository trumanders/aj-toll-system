using Microsoft.EntityFrameworkCore.Migrations;
using Persistence.Contexts;
#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeseedworkflow2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var seedData = SeedDataReader.GetSeedData();

			// Seed FeeInterval (id, fee, start, end)
			foreach (var feeAndIndex in seedData.FeeIntervals.Select((fee, index) => new { fee, index }))
			{
				migrationBuilder.InsertData(
					table: "FeeInterval",
					columns: ["Id", "Fee", "Start", "End"],
					values: [feeAndIndex.index + 1, feeAndIndex.fee.Fee, feeAndIndex.fee.Start, feeAndIndex.fee.End]
				);
			}

			//Seed VehicleTypes (Id, VehicleTypeName, IsTollFree)
			foreach (var typeAndIndex in seedData.VehicleTypes.Select((type, index) => new { type, index }))
			{
				migrationBuilder.InsertData(
					table: "VehicleType",
					columns: ["Id", "VehicleTypeName", "IsTollFree"],
					values: [typeAndIndex.index + 1, typeAndIndex.type.VehicleTypeName, typeAndIndex.type.IsTollFree]
				);
			}

			//Seed SimulatedVehicleApiData (Id, PlateNumber, OwnerName, VehicleTypeName)
			foreach (var dataAndIndex in seedData.SimulatedVehicleApiDataSeedData.Select((data, index) => new { data, index }))
			{
				migrationBuilder.InsertData(
					table: "SimulatedVehicleApiData",
					columns: ["Id", "PlateNumber", "OwnerName", "VehicleTypeName"],
					values: [dataAndIndex.index + 1, dataAndIndex.data.PlateNumber, dataAndIndex.data.OwnerName, dataAndIndex.data.VehicleTypeName]
				);
			}
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

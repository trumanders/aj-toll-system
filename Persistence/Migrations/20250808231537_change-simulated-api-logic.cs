using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changesimulatedapilogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimulatedVehicleApiData_VehicleType_VehicleTypeId",
                table: "SimulatedVehicleApiData");

            migrationBuilder.DropIndex(
                name: "IX_SimulatedVehicleApiData_VehicleTypeId",
                table: "SimulatedVehicleApiData");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "SimulatedVehicleApiData");

            migrationBuilder.AddColumn<string>(
                name: "VehicleTypeName",
                table: "SimulatedVehicleApiData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 1,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 2,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 3,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 4,
                column: "VehicleTypeName",
                value: "Truck");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 5,
                column: "VehicleTypeName",
                value: "Bus");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 6,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 7,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 8,
                column: "VehicleTypeName",
                value: "Military");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 9,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 10,
                column: "VehicleTypeName",
                value: "Truck");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 11,
                column: "VehicleTypeName",
                value: "Truck");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 12,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 13,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 14,
                column: "VehicleTypeName",
                value: "Emergency");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 15,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 16,
                column: "VehicleTypeName",
                value: "Foreign");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 17,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 18,
                column: "VehicleTypeName",
                value: "Military");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 19,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 20,
                column: "VehicleTypeName",
                value: "Bus");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 21,
                column: "VehicleTypeName",
                value: "Tractor");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 22,
                column: "VehicleTypeName",
                value: "Diplomat");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 23,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 24,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 25,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 26,
                column: "VehicleTypeName",
                value: "Foreign");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 27,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 28,
                column: "VehicleTypeName",
                value: "Truck");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 29,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 30,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 31,
                column: "VehicleTypeName",
                value: "Emergency");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 32,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 33,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 34,
                column: "VehicleTypeName",
                value: "Motorcycle");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 35,
                column: "VehicleTypeName",
                value: "Military");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 36,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 37,
                column: "VehicleTypeName",
                value: "Truck");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 38,
                column: "VehicleTypeName",
                value: "Bus");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 39,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 40,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 41,
                column: "VehicleTypeName",
                value: "Military");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 42,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 43,
                column: "VehicleTypeName",
                value: "Truck");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 44,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 45,
                column: "VehicleTypeName",
                value: "Bus");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 46,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 47,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 48,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 49,
                column: "VehicleTypeName",
                value: "Truck");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 50,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 51,
                column: "VehicleTypeName",
                value: "Truck");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 52,
                column: "VehicleTypeName",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 53,
                column: "VehicleTypeName",
                value: "Truck");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleTypeName",
                table: "SimulatedVehicleApiData");

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "SimulatedVehicleApiData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 1,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 2,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 3,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 4,
                column: "VehicleTypeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 5,
                column: "VehicleTypeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 6,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 7,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 8,
                column: "VehicleTypeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 9,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 10,
                column: "VehicleTypeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 11,
                column: "VehicleTypeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 12,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 13,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 14,
                column: "VehicleTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 15,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 16,
                column: "VehicleTypeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 17,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 18,
                column: "VehicleTypeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 19,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 20,
                column: "VehicleTypeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 21,
                column: "VehicleTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 22,
                column: "VehicleTypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 23,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 24,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 25,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 26,
                column: "VehicleTypeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 27,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 28,
                column: "VehicleTypeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 29,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 30,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 31,
                column: "VehicleTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 32,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 33,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 34,
                column: "VehicleTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 35,
                column: "VehicleTypeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 36,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 37,
                column: "VehicleTypeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 38,
                column: "VehicleTypeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 39,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 40,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 41,
                column: "VehicleTypeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 42,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 43,
                column: "VehicleTypeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 44,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 45,
                column: "VehicleTypeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 46,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 47,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 48,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 49,
                column: "VehicleTypeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 50,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 51,
                column: "VehicleTypeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 52,
                column: "VehicleTypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 53,
                column: "VehicleTypeId",
                value: 8);

            migrationBuilder.CreateIndex(
                name: "IX_SimulatedVehicleApiData_VehicleTypeId",
                table: "SimulatedVehicleApiData",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimulatedVehicleApiData_VehicleType_VehicleTypeId",
                table: "SimulatedVehicleApiData",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

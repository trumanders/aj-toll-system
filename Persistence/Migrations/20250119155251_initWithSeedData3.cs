using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initWithSeedData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerName",
                value: "John Thomas");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "OwnerName",
                value: "Chris Miller");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 3,
                column: "OwnerName",
                value: "Jane Moore");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 4,
                column: "OwnerName",
                value: "Casey Moore");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 5,
                column: "OwnerName",
                value: "Casey Davis");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 6,
                column: "OwnerName",
                value: "Morgan Davis");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 7,
                column: "OwnerName",
                value: "Chris Anderson");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 8,
                column: "OwnerName",
                value: "Taylor Moore");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 9,
                column: "OwnerName",
                value: "Alex Johnson");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 10,
                column: "OwnerName",
                value: "Sam Wilson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerName",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "OwnerName",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 3,
                column: "OwnerName",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 4,
                column: "OwnerName",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 5,
                column: "OwnerName",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 6,
                column: "OwnerName",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 7,
                column: "OwnerName",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 8,
                column: "OwnerName",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 9,
                column: "OwnerName",
                value: "");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 10,
                column: "OwnerName",
                value: "");
        }
    }
}

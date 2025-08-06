using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class august : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_VehicleTypes_VehicleTypeId",
                table: "Billings");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfo_VehicleTypes_VehicleTypeId",
                table: "VehicleInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeeIntervals",
                table: "FeeIntervals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billings",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_Billings_VehicleTypeId",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Billings");

            migrationBuilder.RenameTable(
                name: "VehicleTypes",
                newName: "VehicleType");

            migrationBuilder.RenameTable(
                name: "FeeIntervals",
                newName: "FeeInterval");

            migrationBuilder.RenameTable(
                name: "Billings",
                newName: "Billing");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleType",
                table: "VehicleType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeeInterval",
                table: "FeeInterval",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billing",
                table: "Billing",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MonthlyFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccumulatedFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyFee", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfo_VehicleType_VehicleTypeId",
                table: "VehicleInfo",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfo_VehicleType_VehicleTypeId",
                table: "VehicleInfo");

            migrationBuilder.DropTable(
                name: "MonthlyFee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleType",
                table: "VehicleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeeInterval",
                table: "FeeInterval");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billing",
                table: "Billing");

            migrationBuilder.RenameTable(
                name: "VehicleType",
                newName: "VehicleTypes");

            migrationBuilder.RenameTable(
                name: "FeeInterval",
                newName: "FeeIntervals");

            migrationBuilder.RenameTable(
                name: "Billing",
                newName: "Billings");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Billings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "Billings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeeIntervals",
                table: "FeeIntervals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billings",
                table: "Billings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_VehicleTypeId",
                table: "Billings",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_VehicleTypes_VehicleTypeId",
                table: "Billings",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfo_VehicleTypes_VehicleTypeId",
                table: "VehicleInfo",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

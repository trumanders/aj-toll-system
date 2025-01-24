using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TotalDailyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeeIntervals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Start = table.Column<TimeSpan>(type: "time", nullable: false),
                    End = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeIntervals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TotalMonthlyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TollPassages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PassageTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TollPassages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsTollFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleInfo_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMonthlyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billings_VehicleInfo_VehicleInfoId",
                        column: x => x.VehicleInfoId,
                        principalTable: "VehicleInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "FeeIntervals",
                columns: new[] { "Id", "End", "Fee", "Start" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 6, 30, 0, 0), 9m, new TimeSpan(0, 6, 0, 0, 0) },
                    { 2, new TimeSpan(0, 15, 0, 0, 0), 9m, new TimeSpan(0, 8, 30, 0, 0) },
                    { 3, new TimeSpan(0, 18, 30, 0, 0), 9m, new TimeSpan(0, 18, 0, 0, 0) },
                    { 4, new TimeSpan(0, 7, 0, 0, 0), 16m, new TimeSpan(0, 6, 30, 0, 0) },
                    { 5, new TimeSpan(0, 8, 30, 0, 0), 16m, new TimeSpan(0, 8, 0, 0, 0) },
                    { 6, new TimeSpan(0, 15, 30, 0, 0), 16m, new TimeSpan(0, 15, 0, 0, 0) },
                    { 7, new TimeSpan(0, 18, 0, 0, 0), 16m, new TimeSpan(0, 17, 0, 0, 0) },
                    { 8, new TimeSpan(0, 8, 0, 0, 0), 22m, new TimeSpan(0, 7, 0, 0, 0) },
                    { 9, new TimeSpan(0, 17, 0, 0, 0), 22m, new TimeSpan(0, 15, 30, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billings_VehicleInfoId",
                table: "Billings",
                column: "VehicleInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfo_VehicleTypeId",
                table: "VehicleInfo",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "DailyFees");

            migrationBuilder.DropTable(
                name: "FeeIntervals");

            migrationBuilder.DropTable(
                name: "MonthlyFees");

            migrationBuilder.DropTable(
                name: "TollPassages");

            migrationBuilder.DropTable(
                name: "VehicleInfo");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ajtollsystemdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccumulatedFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billings_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "IsTollFree", "TypeName" },
                values: new object[,]
                {
                    { 1, true, "Motorcycle" },
                    { 2, true, "Tractor" },
                    { 3, true, "Emergency" },
                    { 4, true, "Diplomat" },
                    { 5, true, "Foreign" },
                    { 6, true, "Military" },
                    { 7, false, "Car" },
                    { 8, false, "Truck" },
                    { 9, false, "Bus" }
                });

            migrationBuilder.InsertData(
                table: "VehicleInfo",
                columns: new[] { "Id", "OwnerName", "PlateNumber", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, "Tommy Tjernqvist", "PTP461", 7 },
                    { 2, "Hugo Håkman", "FJN740", 7 },
                    { 3, "Linda Längström", "ZCX563", 7 },
                    { 4, "Kalle Krantz", "VAT087", 8 },
                    { 5, "Benny Bäckström", "CUL352", 9 },
                    { 6, "Ronny Röjberg", "UXL821", 7 },
                    { 7, "Sally Ståhl", "MKW921", 7 },
                    { 8, "Eddie Elg", "OLU514", 6 },
                    { 9, "Felix Färnelund", "TJY229", 7 },
                    { 10, "Jörgen Järvstad", "UHA649", 8 },
                    { 11, "Lotta Löfgren", "BTS372", 8 },
                    { 12, "Gustav Gullberg", "XKL291", 7 },
                    { 13, "Mona Mörk", "PNY183", 7 },
                    { 14, "Oscar Olofsson", "KLM562", 3 },
                    { 15, "Victor Vallén", "RMJ473", 7 },
                    { 16, "Jenny Järp", "QWE982", 5 },
                    { 17, "Stina Sörlén", "TRP648", 7 },
                    { 18, "Axel Åkesson", "ZXC101", 6 },
                    { 19, "Nina Norrström", "LPO839", 7 },
                    { 20, "Felicia Forslund", "GHT467", 9 },
                    { 21, "Greta Gerdman", "KLB381", 2 },
                    { 22, "Erik Eklund", "XOP122", 4 },
                    { 23, "Beatrice Boström", "WZX771", 7 },
                    { 24, "Fredrik Friberg", "HUE294", 7 },
                    { 25, "Astrid Albinsson", "LPD450", 7 },
                    { 26, "Sigge Sandström", "PRT999", 5 },
                    { 27, "Kajsa Källström", "KNL238", 7 },
                    { 28, "Torvald Tollberg", "UBK768", 8 },
                    { 29, "Lilly Lind", "EMG482", 7 },
                    { 30, "Bertil Bäckström", "JNH590", 7 },
                    { 31, "Hanna Hultgren", "JOL342", 3 },
                    { 32, "Dagmar Dahlen", "WMD229", 7 },
                    { 33, "Oskar Odelberg", "TYC992", 7 },
                    { 34, "Clara Carlsson", "TRD147", 1 },
                    { 35, "Harry Hägglund", "BXA321", 6 },
                    { 36, "Elsa Eklund", "PLT465", 7 },
                    { 37, "Ulf Ulander", "GFX109", 8 },
                    { 38, "Märta Melin", "LSQ555", 9 },
                    { 39, "Simon Stenberg", "NKI211", 7 },
                    { 40, "Ingrid Irén", "FPZ830", 7 },
                    { 41, "Göran Gidlund", "TXR871", 6 },
                    { 42, "Camilla Carlsson", "WQL130", 7 },
                    { 43, "Roland Rindberg", "BYH376", 8 },
                    { 44, "Lina Ljungholm", "ZCP591", 7 },
                    { 45, "Björn Björkman", "TDA643", 9 },
                    { 46, "Stella Sörensson", "CBX008", 7 },
                    { 47, "Einar Engström", "HKO483", 7 },
                    { 48, "Emilia Ekberg", "WLQ599", 7 },
                    { 49, "Kristian Karlsson", "YSQ102", 8 },
                    { 50, "Viola Vinge", "RGX702", 7 },
                    { 51, "Torsten Törnqvist", "MTF981", 8 },
                    { 52, "Ellinor Elm", "GQV753", 7 },
                    { 53, "Sven Svahn", "HZX610", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billings_VehicleTypeId",
                table: "Billings",
                column: "VehicleTypeId");

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
                name: "FeeIntervals");

            migrationBuilder.DropTable(
                name: "VehicleInfo");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}

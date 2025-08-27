using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class enableseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FeeInterval",
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
                table: "SimulatedVehicleApiData",
                columns: new[] { "Id", "OwnerName", "PlateNumber", "VehicleTypeName" },
                values: new object[,]
                {
                    { 1, "Tommy Tjernqvist", "PTP461", "CAR" },
                    { 2, "Hugo Håkman", "FJN740", "CAR" },
                    { 3, "Linda Längström", "ZCX563", "CAR" },
                    { 4, "Kalle Krantz", "VAT087", "TRUCK" },
                    { 5, "Benny Bäckström", "CUL352", "BUS" },
                    { 6, "Ronny Röjberg", "UXL821", "CAR" },
                    { 7, "Sally Ståhl", "MKW921", "CAR" },
                    { 8, "Eddie Elg", "OLU514", "MILITARY" },
                    { 9, "Felix Färnelund", "TJY229", "CAR" },
                    { 10, "Jörgen Järvstad", "UHA649", "TRUCK" },
                    { 11, "Lotta Löfgren", "BTS372", "TRUCK" },
                    { 12, "Gustav Gullberg", "XKL291", "CAR" },
                    { 13, "Mona Mörk", "PNY183", "CAR" },
                    { 14, "OsCAR Olofsson", "KLM562", "EMERGENCY" },
                    { 15, "Victor Vallén", "RMJ473", "CAR" },
                    { 16, "Jenny Järp", "QWE982", "FOREIGN" },
                    { 17, "Stina Sörlén", "TRP648", "CAR" },
                    { 18, "Axel Åkesson", "ZXC101", "MILITARY" },
                    { 19, "Nina Norrström", "LPO839", "CAR" },
                    { 20, "Felicia Forslund", "GHT467", "BUS" },
                    { 21, "Greta Gerdman", "KLB381", "TRACTOR" },
                    { 22, "Erik Eklund", "XOP122", "DIPLOMAT" },
                    { 23, "Beatrice Boström", "WZX771", "CAR" },
                    { 24, "Fredrik Friberg", "HUE294", "CAR" },
                    { 25, "Astrid Albinsson", "LPD450", "CAR" },
                    { 26, "Sigge Sandström", "PRT999", "FOREIGN" },
                    { 27, "Kajsa Källström", "KNL238", "CAR" },
                    { 28, "Torvald Tollberg", "UBK768", "TRUCK" },
                    { 29, "Lilly Lind", "EMG482", "CAR" },
                    { 30, "Bertil Bäckström", "JNH590", "CAR" },
                    { 31, "Hanna Hultgren", "JOL342", "EMERGENCY" },
                    { 32, "Dagmar Dahlen", "WMD229", "CAR" },
                    { 33, "Oskar Odelberg", "TYC992", "CAR" },
                    { 34, "Clara CARlsson", "TRD147", "MOTORCYCLE" },
                    { 35, "Harry Hägglund", "BXA321", "MILITARY" },
                    { 36, "Elsa Eklund", "PLT465", "CAR" },
                    { 37, "Ulf Ulander", "GFX109", "TRUCK" },
                    { 38, "Märta Melin", "LSQ555", "BUS" },
                    { 39, "Simon Stenberg", "NKI211", "CAR" },
                    { 40, "Ingrid Irén", "FPZ830", "CAR" },
                    { 41, "Göran Gidlund", "TXR871", "MILITARY" },
                    { 42, "Camilla CARlsson", "WQL130", "CAR" },
                    { 43, "Roland Rindberg", "BYH376", "TRUCK" },
                    { 44, "Lina Ljungholm", "ZCP591", "CAR" },
                    { 45, "Björn Björkman", "TDA643", "BUS" },
                    { 46, "Stella Sörensson", "CBX008", "CAR" },
                    { 47, "Einar Engström", "HKO483", "CAR" },
                    { 48, "Emilia Ekberg", "WLQ599", "CAR" },
                    { 49, "Kristian Karlsson", "YSQ102", "TRUCK" },
                    { 50, "Viola Vinge", "RGX702", "CAR" },
                    { 51, "Torsten Törnqvist", "MTF981", "TRUCK" },
                    { 52, "Ellinor Elm", "GQV753", "CAR" },
                    { 53, "Sven Svahn", "HZX610", "TRUCK" }
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "IsTollFree", "VehicleTypeName" },
                values: new object[,]
                {
                    { 1, true, "MOTORCYCLE" },
                    { 2, true, "TRACTOR" },
                    { 3, true, "EMERGENCY" },
                    { 4, true, "DIPLOMAT" },
                    { 5, true, "FOREIGN" },
                    { 6, true, "MILITARY" },
                    { 7, false, "CAR" },
                    { 8, false, "TRUCK" },
                    { 9, false, "BUS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeeInterval",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FeeInterval",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FeeInterval",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FeeInterval",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FeeInterval",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FeeInterval",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FeeInterval",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FeeInterval",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FeeInterval",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "SimulatedVehicleApiData",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}

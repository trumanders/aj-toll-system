using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ajtollsystem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerName",
                value: "Tommy Tjernqvist");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "OwnerName",
                value: "Hugo Håkman");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 3,
                column: "OwnerName",
                value: "Linda Längström");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 4,
                column: "OwnerName",
                value: "Kalle Krantz");

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Benny Bäckström", 9 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Ronny Röjberg", 7 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Sally Ståhl", 7 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Eddie Elg", 6 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Felix Färnelund", 7 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Jörgen Järvstad", 8 });

            migrationBuilder.InsertData(
                table: "VehicleInfo",
                columns: new[] { "Id", "OwnerName", "PlateNumber", "VehicleTypeId" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 53);

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
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Casey Davis", 8 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Morgan Davis", 9 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Chris Anderson", 9 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Taylor Moore", 9 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Alex Johnson", 2 });

            migrationBuilder.UpdateData(
                table: "VehicleInfo",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OwnerName", "VehicleTypeId" },
                values: new object[] { "Sam Wilson", 1 });
        }
    }
}

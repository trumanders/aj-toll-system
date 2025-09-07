using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
	/// <inheritdoc />
	public partial class changeseedworkflowhardcoded : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			// Seed FeeInterval (Id, Fee, Start, End)
			migrationBuilder.InsertData(
				table: "FeeInterval",
				columns: new[] { "Id", "Fee", "Start", "End" },
				values: new object[,]
				{
					{ 1, 9, new TimeSpan(6, 0, 0), new TimeSpan(6, 30, 0) },
					{ 2, 16, new TimeSpan(6, 30, 0), new TimeSpan(7, 0, 0) },
					{ 3, 22, new TimeSpan(7, 0, 0), new TimeSpan(8, 0, 0) },
					{ 4, 9, new TimeSpan(8, 30, 0), new TimeSpan(15, 0, 0) },
					{ 5, 16, new TimeSpan(8, 0, 0), new TimeSpan(8, 30, 0) },
					{ 6, 16, new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0) },
					{ 7, 22, new TimeSpan(15, 30, 0), new TimeSpan(17, 0, 0) },
					{ 8, 16, new TimeSpan(17, 0, 0), new TimeSpan(18, 0, 0) },
					{ 9, 9, new TimeSpan(18, 0, 0), new TimeSpan(18, 30, 0) },
				}
			);

			// Seed VehicleType (Id, VehicleTypeName, IsTollFree)
			migrationBuilder.InsertData(
				table: "VehicleType",
				columns: new[] { "Id", "VehicleTypeName", "IsTollFree" },
				values: new object[,]
				{
					{ 1, "MOTORCYCLE", true },
					{ 2, "TRACTOR", true },
					{ 3, "EMERGENCY", true },
					{ 4, "DIPLOMAT", true },
					{ 5, "FOREIGN", true },
					{ 6, "MILITARY", true },
					{ 7, "CAR", false },
					{ 8, "TRUCK", false },
					{ 9, "BUS", false },
				}
			);

			// Seed SimulatedVehicleApiData (Id, PlateNumber, OwnerName, VehicleTypeName)
			migrationBuilder.InsertData(
				table: "SimulatedVehicleApiData",
				columns: new[] { "Id", "PlateNumber", "OwnerName", "VehicleTypeName" },
				values: new object[,]
				{
					{ 1, "PTP461", "Tommy Tjernqvist", "CAR" },
					{ 2, "FJN740", "Hugo Håkman", "CAR" },
					{ 3, "ZCX563", "Linda Längström", "CAR" },
					{ 4, "VAT087", "Kalle Krantz", "TRUCK" },
					{ 5, "CUL352", "Benny Bäckström", "BUS" },
					{ 6, "UXL821", "Ronny Röjberg", "CAR" },
					{ 7, "MKW921", "Sally Ståhl", "CAR" },
					{ 8, "OLU514", "Eddie Elg", "MILITARY" },
					{ 9, "TJY229", "Felix Färnelund", "CAR" },
					{ 10, "UHA649", "Jörgen Järvstad", "TRUCK" },
					{ 11, "BTS372", "Lotta Löfgren", "TRUCK" },
					{ 12, "XKL291", "Gustav Gullberg", "CAR" },
					{ 13, "PNY183", "Mona Mörk", "CAR" },
					{ 14, "KLM562", "OsCAR Olofsson", "EMERGENCY" },
					{ 15, "RMJ473", "Victor Vallén", "CAR" },
					{ 16, "QWE982", "Jenny Järp", "FOREIGN" },
					{ 17, "TRP648", "Stina Sörlén", "CAR" },
					{ 18, "ZXC101", "Axel Åkesson", "MILITARY" },
					{ 19, "LPO839", "Nina Norrström", "CAR" },
					{ 20, "GHT467", "Felicia Forslund", "BUS" },
					{ 21, "KLB381", "Greta Gerdman", "TRACTOR" },
					{ 22, "XOP122", "Erik Eklund", "DIPLOMAT" },
					{ 23, "WZX771", "Beatrice Boström", "CAR" },
					{ 24, "HUE294", "Fredrik Friberg", "CAR" },
					{ 25, "LPD450", "Astrid Albinsson", "CAR" },
					{ 26, "PRT999", "Sigge Sandström", "FOREIGN" },
					{ 27, "KNL238", "Kajsa Källström", "CAR" },
					{ 28, "UBK768", "Torvald Tollberg", "TRUCK" },
					{ 29, "EMG482", "Lilly Lind", "CAR" },
					{ 30, "JNH590", "Bertil Bäckström", "CAR" },
					{ 31, "JOL342", "Hanna Hultgren", "EMERGENCY" },
					{ 32, "WMD229", "Dagmar Dahlen", "CAR" },
					{ 33, "TYC992", "Oskar Odelberg", "CAR" },
					{ 34, "TRD147", "Clara CARlsson", "MOTORCYCLE" },
					{ 35, "BXA321", "Harry Hägglund", "MILITARY" },
					{ 36, "PLT465", "Elsa Eklund", "CAR" },
					{ 37, "GFX109", "Ulf Ulander", "TRUCK" },
					{ 38, "LSQ555", "Märta Melin", "BUS" },
					{ 39, "NKI211", "Simon Stenberg", "CAR" },
					{ 40, "FPZ830", "Ingrid Irén", "CAR" },
					{ 41, "TXR871", "Göran Gidlund", "MILITARY" },
					{ 42, "WQL130", "Camilla CARlsson", "CAR" },
					{ 43, "BYH376", "Roland Rindberg", "TRUCK" },
					{ 44, "ZCP591", "Lina Ljungholm", "CAR" },
					{ 45, "TDA643", "Björn Björkman", "BUS" },
					{ 46, "CBX008", "Stella Sörensson", "CAR" },
					{ 47, "HKO483", "Einar Engström", "CAR" },
					{ 48, "WLQ599", "Emilia Ekberg", "CAR" },
					{ 49, "YSQ102", "Kristian Karlsson", "TRUCK" },
					{ 50, "RGX702", "Viola Vinge", "CAR" },
					{ 51, "MTF981", "Torsten Törnqvist", "TRUCK" },
					{ 52, "GQV753", "Ellinor Elm", "CAR" },
					{ 53, "HZX610", "Sven Svahn", "TRUCK" },
				}
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) { }
	}
}

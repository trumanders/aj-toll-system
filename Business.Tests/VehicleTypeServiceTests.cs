namespace Business.Tests;

[TestFixture]
public class VehicleTypeServiceTests
{
	private readonly IVehicleTypeService _sut;
	private readonly IDbService _fakeDbService;

	private readonly List<TollCameraData> _fakeTollCameraData =
	[
		new() { PlateNumber = "AAA111" },
		new() { PlateNumber = "BBB222" },
		new() { PlateNumber = "CCC333" },
		new() { PlateNumber = "DDD444" },
		new() { PlateNumber = "EEE555" },
		new() { PlateNumber = "FFF666" },
		new() { PlateNumber = "GGG777" },
		new() { PlateNumber = "HHH888" },
		new() { PlateNumber = "III999" },
	];

	private readonly List<SimulatedVehicleApiDataPlateAndType> _fakeSimulatedVehicleApiData =
	[
		new() { PlateNumber = "AAA111", VehicleTypeName = "TollFree" },
		new() { PlateNumber = "BBB222", VehicleTypeName = "TollFree" },
		new() { PlateNumber = "CCC333", VehicleTypeName = "NonTollFree" },
		new() { PlateNumber = "DDD444", VehicleTypeName = "TollFree" },
		new() { PlateNumber = "EEE555", VehicleTypeName = "NonTollFree" },
		new() { PlateNumber = "FFF666", VehicleTypeName = "TollFree" },
		new() { PlateNumber = "GGG777", VehicleTypeName = "TollFree" },
		new() { PlateNumber = "HHH888", VehicleTypeName = "TollFree" },
		new() { PlateNumber = "III999", VehicleTypeName = "TollFree" },
	];

	private readonly List<VehicleTypeDbStub> _fakeVehicleTypes =
	[
		new() { VehicleTypeName = "NonTollFree", IsTollFree = false },
		new() { VehicleTypeName = "TollFree", IsTollFree = true },
	];

	public VehicleTypeServiceTests()
	{
		_fakeDbService = A.Fake<IDbService>();
		_sut = new VehicleTypeService(_fakeDbService);
	}

	[Test]
	public async Task FilterOutTollFreeVehiclesAsyncTest_ResultDoesNotContainTollFreeVehicles()
	{
		// Arrange
		A.CallTo(() => _fakeDbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataPlateAndType>
			(A<Expression<Func<SimulatedVehicleApiData, bool>>>._)
		)
		.ReturnsLazily(call => Task.FromResult(_fakeSimulatedVehicleApiData
			.Where(dto => _fakeTollCameraData.Select(p => p.PlateNumber)
				.Contains(dto.PlateNumber))
			.ToList())
		);

		A.CallTo(() => _fakeDbService.GetAsync<VehicleType, VehicleTypeModel>(A<Expression<Func<VehicleType, bool>>>._))
			.ReturnsLazily(call => Task.FromResult(_fakeVehicleTypes
				.Where(x => x.IsTollFree)
				.Select(x => new VehicleTypeModel
				{
					VehicleTypeName = x.VehicleTypeName
				})
				.ToList()
			)
		);

		// Act
		var actualResult = await _sut.FilterOutTollFreeVehiclesAsync(_fakeTollCameraData);

		var expectedResult = new List<TollPassageData>()
		{
			new() { PlateNumber = "CCC333" },
			new() { PlateNumber = "EEE555" },
		};

		// Assert
		Assert.That(
			actualResult.Select(x => x.PlateNumber),
			Is.EquivalentTo(expectedResult.Select(x => x.PlateNumber))
		);
	}
}

public class VehicleTypeDbStub
{
	public string? VehicleTypeName { get; set; }
	public bool IsTollFree { get; set; }
}

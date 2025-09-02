namespace Business.Tests;

[TestFixture]
public class FeeServiceTests
{
	private IFeeService _sut;
	private IDbService _fakeDbService;
	private ITollFreeDaysService _fakeTollFreeDaysService;
	private IFeeService _fakeFeeService;

	private readonly List<FeeIntervalDTO> _fakeFeeIntervals =
	[
		new () { Fee = 9,  Start = new TimeSpan(6, 0, 0),  End = new TimeSpan(6, 30, 0) },
		new () { Fee = 16, Start = new TimeSpan(6, 30, 0), End = new TimeSpan(7, 0, 0) },
		new () { Fee = 22, Start = new TimeSpan(7, 0, 0),  End = new TimeSpan(8, 0, 0) },
		new () { Fee = 9,  Start = new TimeSpan(8, 30, 0), End = new TimeSpan(15, 0, 0) },
		new () { Fee = 16, Start = new TimeSpan(8, 0, 0),  End = new TimeSpan(8, 30, 0) },
		new () { Fee = 16, Start = new TimeSpan(15, 0, 0), End = new TimeSpan(15, 30, 0) },
		new () { Fee = 22, Start = new TimeSpan(15, 30, 0), End = new TimeSpan(17, 0, 0) },
		new () { Fee = 16, Start = new TimeSpan(17, 0, 0), End = new TimeSpan(18, 0, 0) },
		new () { Fee = 9,  Start = new TimeSpan(18, 0, 0), End = new TimeSpan(18, 30, 0) }
	];

	private readonly List<TollPassageData> _tollPassagesWithoutFee =
	[
		new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59), VehicleTypeName = "Car" },	// (16) (0, next is within hour and higher)
		new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 0, 0), VehicleTypeName = "Car" },	// 22

		new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59), VehicleTypeName = "Car" },	// 22
		new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 8, 0, 0), VehicleTypeName = "Car" },	// (16) (0, is within hour from previous which is higher)

		new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 10, 00, 00), VehicleTypeName = "Car" },// 9

		new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 5, 59, 59), VehicleTypeName = "Car" },	// 0

		new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0), VehicleTypeName = "Car" },	// (9) (0, next is within hour and higher)
		new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59), VehicleTypeName = "Car" },	// 16

		new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59), VehicleTypeName = "Car" },	// 22
		new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 8, 00, 00), VehicleTypeName = "Car" }  // (16) (0, within hour from previous which is higher)
	];

	private readonly List<decimal> _tollPassagesWithoutFeeExpectedFees = [22, 22, 9, 16, 22];

[SetUp]
	public void SetUp()
	{
		_fakeDbService = A.Fake<IDbService>();
		_sut = new FeeService(_fakeDbService);
		_fakeTollFreeDaysService = A.Fake<ITollFreeDaysService>();
		_fakeFeeService = A.Fake<IFeeService>();
	}

	[Test]
	public void ApplyFeeToAllPassages_WhenNoVehicleTypeExists_ThrowsArgumentException()
	{
		// Arrange
		var passageDataWithoutVehicleType = new List<TollPassageData>()
		{ new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0) } };

		// Act & Assert
		var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _sut.ApplyFeeToAllPassages(passageDataWithoutVehicleType));
		Assert.That(ex.Message, Is.EqualTo("VehicleType is required. Please include vehicle type in the request."));
	}

	[Test]
	public void ApplyFeeToAllPassages_WhenNoFeeIntervalsExist_ThrowInvalidOperationExeption()
	{
		// Arrange
		var anyTollPassageData = new List<TollPassageData>()
		{ new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0), VehicleTypeName = "Car" } };

		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalDTO>()).Returns([]);
		var exception = Assert.ThrowsAsync<InvalidOperationException>(async () => await _sut.ApplyFeeToAllPassages(anyTollPassageData));
		Assert.That(exception.Message, Is.EqualTo("There are no fee intervals available."));
	}

	[Test]
	public async Task ApplyFeeToAllPassages_ReturnsCorrectFees()
	{
		// Arrange
		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalDTO>()).Returns(_fakeFeeIntervals);

		// Act
		var actualFees = (await _sut.ApplyFeeToAllPassages(_tollPassagesWithoutFee)).Select(x => x.Fee).ToList();

		Assert.That(actualFees
			.Zip(_tollPassagesWithoutFeeExpectedFees, (actual, expected) => actual == expected)
			.All(x => x), Is.True);
	}

	[Test]
	public async Task ApplyFeeToAllPassages_OnlyKeepPassagesWithFee()
	{
		// Arrange
		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalDTO>()).Returns(_fakeFeeIntervals);

		// Act
		var actualFees = (await _sut.ApplyFeeToAllPassages(_tollPassagesWithoutFee)).Select(x => x.Fee).ToList();


		// Assert
		Assert.That(actualFees.All(fee => fee > 0), Is.True);
	}

	[Test]
	public void GetDailyFeeSummaryForEachVehicle_WhenValidInputProvided_ReturnsCorrectDailyFees()
	{
		// Arrange
		var tollPassageData = new List<TollPassageData>
		{
			new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59), VehicleTypeName = "Car", Fee = 0 },
			new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 0, 0), VehicleTypeName = "Car", Fee = 22 },
			new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59), VehicleTypeName = "Car", Fee = 22 },
			new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 8, 0, 0), VehicleTypeName = "Car", Fee = 0 },
			new () { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 10, 00, 00), VehicleTypeName = "Car", Fee = 9 },
			new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 5, 59, 59), VehicleTypeName = "Car", Fee = 0 },
			new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0), VehicleTypeName = "Car", Fee = 0 },
			new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59), VehicleTypeName = "Car", Fee = 16 },
			new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59), VehicleTypeName = "Car", Fee = 22 },
			new () { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 8, 00, 00), VehicleTypeName = "Car", Fee = 0 }
		};

		var expectedFees = new List<decimal> { 53, 38 };

		// Act	
		var actualFees = _sut.GetDailyFeeSummaryForEachVehicle(tollPassageData).Select(x => x.DailyFee).ToList();

		// Assert
		Assert.That(actualFees
			.Zip(expectedFees, (actual, expected) => actual == expected).All(x => x), Is.True);
	}

	[Test]
	public void GetDailyFeeSummaryForEachVehicle_WhenNoFeesApplied_ThrowInvalidOperationException()
	{
		// Arrange
		var tollPassagesWithoutFees = new List<TollPassageData>
		{
			new() { PlateNumber = "AAA111", PassageTime = new DateTime(2025, 1, 20, 7, 40, 0) }
		};

		// Act & Assert
		var exception = Assert.Throws<InvalidOperationException>(() => _sut.GetDailyFeeSummaryForEachVehicle(tollPassagesWithoutFees));
		Assert.That(exception.Message, Is.EqualTo("The passages must have fees applied to calculate the total daily fee"));
	}

	[Test]
	public void GetDailyFeeSummaryForEachVehicle_WhenDailyFeeExceedsMaxDailyFee_ReturnsMaxDailyFee()
	{
		// Arrange
		var vehicleTollPassages = new List<TollPassageData>
		{
			new() { PlateNumber = "AAA111", PassageTime = new DateTime(2025, 1, 20, 7, 40, 0), Fee = 22 },
			new() { PlateNumber = "AAA111", PassageTime = new DateTime(2025, 1, 20, 15, 30, 0), Fee = 22 },
			new() { PlateNumber = "AAA111", PassageTime = new DateTime(2025, 1, 20, 16, 40, 0), Fee = 22 },
			new() { PlateNumber = "XXX999", PassageTime = new DateTime(2025, 1, 20, 7, 40, 0), Fee = 22 },
			new() { PlateNumber = "XXX999", PassageTime = new DateTime(2025, 1, 20, 15, 30, 0), Fee = 22 },
			new() { PlateNumber = "XXX999", PassageTime = new DateTime(2025, 1, 20, 16, 40, 0), Fee = 22 }

		};

		var maxDailyFee = _sut.GetMaxDailyFee();

		// Act	
		var actualDailyFees = _sut.GetDailyFeeSummaryForEachVehicle(vehicleTollPassages).Select(x => x.DailyFee).ToList();

		// Assert
		Assert.That(actualDailyFees.All(fee => fee <= maxDailyFee));
	}
}


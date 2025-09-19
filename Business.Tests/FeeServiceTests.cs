namespace Business.Tests;

[TestFixture]
public class FeeServiceTests
{
	public readonly IDbService _fakeDbService = A.Fake<IDbService>();
	private IFeeService _sut;

	private readonly List<FeeIntervalModel> _fakeFeeIntervals =
	[
		new() { Fee = 9, Start = new TimeSpan(6, 0, 0), End = new TimeSpan(6, 30, 0) },
		new() { Fee = 16, Start = new TimeSpan(6, 30, 0), End = new TimeSpan(7, 0, 0) },
		new() { Fee = 22, Start = new TimeSpan(7, 0, 0), End = new TimeSpan(8, 0, 0) },
		new() { Fee = 9, Start = new TimeSpan(8, 30, 0), End = new TimeSpan(15, 0, 0) },
		new() { Fee = 16, Start = new TimeSpan(8, 0, 0), End = new TimeSpan(8, 30, 0) },
		new() { Fee = 16, Start = new TimeSpan(15, 0, 0), End = new TimeSpan(15, 30, 0) },
		new() { Fee = 22, Start = new TimeSpan(15, 30, 0), End = new TimeSpan(17, 0, 0) },
		new() { Fee = 16, Start = new TimeSpan(17, 0, 0), End = new TimeSpan(18, 0, 0) },
		new() { Fee = 9, Start = new TimeSpan(18, 0, 0), End = new TimeSpan(18, 30, 0) },
	];

	private readonly List<TollPassageData> _tollPassagesWithoutFee =
	[
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59) }, // (16) (0, next is within hour and higher)
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 0, 0) }, // 22
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59) }, // 22
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 8, 0, 0) }, // (16) (0, is within hour from previous which is higher)
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 10, 00, 00) }, // 9
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 5, 59, 59) }, // 0
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0) }, // (9) (0, next is within hour and higher)
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59) }, // 16
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59) }, // 22
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 8, 00, 00) }, // (16) (0, within hour from previous which is higher)
	];

	private readonly List<decimal> _tollPassagesWithoutFeeExpectedFees = [22, 22, 9, 16, 22];

	private readonly List<TollPassageData> _tollPassagesWithFee =
	[
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59), Fee = 0 },
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 0, 0), Fee = 22 },
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59), Fee = 22 },
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 8, 0, 0), Fee = 0 },
		new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 10, 0, 0), Fee = 9 },
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 5, 59, 59), Fee = 0 },
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0), Fee = 0 },
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59), Fee = 16 },
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59), Fee = 22 },
		new() { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 8, 0, 0), Fee = 0 }
	];

	[SetUp]
	public void SetUp()
	{
		_sut = new FeeService(_fakeDbService);
	}

	[Test]
	public void ApplyFeeToAllPassages_WhenNoFeeIntervalsExist_ThrowInvalidOperationExeption()
	{
		// Arrange
		var anyTollPassageData = new List<TollPassageData>()
		{
			new() { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0) },
		};

		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalModel>()).Returns([]);

		// Act & Assert
		var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await _sut.ApplyFeeToAllPassages(anyTollPassageData)
		);
		Assert.That(exception.Message, Is.EqualTo("There are no fee intervals available."));
	}

	[Test]
	public async Task ApplyFeeToAllPassages_ReturnsCorrectFees()
	{
		// Arrange
		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalModel>())
			.Returns(_fakeFeeIntervals);

		// Act
		var actualFees = (await _sut.ApplyFeeToAllPassages(_tollPassagesWithoutFee))
			.Select(x => x.Fee)
			.ToList();

		Assert.That(
			actualFees
				.Zip(_tollPassagesWithoutFeeExpectedFees, (actual, expected) => actual == expected)
				.All(x => x),
			Is.True
		);
	}

	[Test]
	public async Task ApplyFeeToAllPassages_OnlyKeepPassagesWithFee()
	{
		// Arrange
		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalModel>())
			.Returns(_fakeFeeIntervals);

		// Act
		var actualFees = (await _sut.ApplyFeeToAllPassages(_tollPassagesWithoutFee))
			.Select(x => x.Fee)
			.ToList();

		// Assert
		Assert.That(actualFees.All(fee => fee > 0), Is.True);
	}

	[Test]
	public async Task CreateDailyFeeSummaryForEachVehicle_WhenValidInputProvided_ShouldReturnCorrectDailyFees()
	{
		// Arrange
		var tollPassages = new List<TollPassageData>
		{
			new() { PlateNumber = "ABC123", PassageTime = new DateTime(2022, 2, 2, 8, 0, 0), Fee = 10, },
			new() { PlateNumber = "ABC123", PassageTime = new DateTime(2022, 2, 2, 8, 0, 0), Fee = 10, },
			new() { PlateNumber = "CBA321", PassageTime = new DateTime(2022, 2, 2, 8, 0, 0), Fee = 20, },
			new() { PlateNumber = "CBA321", PassageTime = new DateTime(2022, 2, 2, 8, 0, 0), Fee = 20, }
		};

		var expectedFees = new List<decimal> { 20, 40 };

		// Act
		var actualFees = _sut.CreateDailyFeeSummaryForEachVehicle(tollPassages)
			.Select(x => x.DailyFee)
			.ToList();

		// Assert
		Assert.That(
			actualFees.Zip(expectedFees, (actual, expected) => actual == expected).All(x => x),
			Is.True
		);
	}

	[Test]
	public void SaveDailyFeeSummaryForEachVehicle_WhenNoFeesApplied_ShouldThrowInvalidOperationException()
	{
		// Arrange
		var tollPassagesWithoutFees = new List<TollPassageData>
		{
			new() { PlateNumber = "AAA111", PassageTime = new DateTime(2025, 1, 20, 7, 40, 0) },
		};

		// Act & Assert
		var exception = Assert.ThrowsAsync<InvalidOperationException>(() =>
			_sut.SaveDailyFeeSummaryForEachVehicle(tollPassagesWithoutFees)
		);

		Assert.That(exception.Message, Is.EqualTo("The passages must have fees applied to calculate the total daily fee"));
	}

	[Test]
	public void CreateDailyFeeSummaryForEachVehicle_WhenDailyFeeExceedsMaxDailyFee_ShouldReturnMaxDailyFee()
	{
		// Arrange
		var maxDailyFee = _sut.GetMaxDailyFee();

		// Act
		var actualDailyFees = _sut.CreateDailyFeeSummaryForEachVehicle(_tollPassagesWithFee)
			.Select(x => x.DailyFee)
			.ToList();

		// Assert
		Assert.That(actualDailyFees.All(fee => fee <= maxDailyFee));
	}

	[Test]
	public void SaveDailyFeeSummaryForEachVehicle_WhenSavingDailyFeesForAlreadyExistingDate_ShouldThrowException()
	{
		// Arrange
		var existingDailyFeesDbStub = new List<VehicleDailyFee>
		{
			new() { PlateNumber = "ABC123", DailyFee = 41, Date = new DateTime(2022, 2, 2) },
			new() { PlateNumber = "CBA321", DailyFee = 60, Date = new DateTime(2022, 2, 3) }
		};

		var tollPassagesToCheck = new List<TollPassageData>
		{
			new() { PlateNumber = "AAA111", PassageTime = new DateTime(2022, 2, 2, 8, 0, 0), Fee = 1},
			new() { PlateNumber = "BBB222", PassageTime = new DateTime(2022, 2, 2, 9, 0, 0), Fee = 2}
		};

		A.CallTo(() => _fakeDbService.CheckDailyFeeExistingDate(A<DateOnly>._))
			.ReturnsLazily(call => Task.FromResult(existingDailyFeesDbStub
				.Any(dailyFeeDbStub => DateOnly.FromDateTime(dailyFeeDbStub.Date) == call.GetArgument<DateOnly>(0))));

		// Act & Assert 
		var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await _sut.SaveDailyFeeSummaryForEachVehicle(tollPassagesToCheck));

		Assert.That(exception.Message, Is.EqualTo("There are already daily fees saved for the same date"));
	}
}

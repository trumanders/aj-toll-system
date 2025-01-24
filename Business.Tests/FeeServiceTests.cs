namespace Business.Tests;

[TestFixture]
public class FeeServiceTests
{
	private IFeeService _sut;
	private IDbService _fakeDbService;

	[SetUp]
	public void SetUp()
	{
		_fakeDbService = A.Fake<IDbService>();
		_sut = new FeeService(_fakeDbService);
	}

	[Test]
	public void GetTotalFeeForVehiclePassages_WhenValidInputProvided_ReturnsCorrectDailyFee()
	{
		// Arrange
		var fakeIntervals = new List<FeeIntervalDTO>
		{
			new FeeIntervalDTO { Start = new TimeSpan(6, 0, 0), End = new TimeSpan(7, 0, 0), Fee = 10 },
			new FeeIntervalDTO { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(8, 0, 0), Fee = 20 },
			new FeeIntervalDTO { Start = new TimeSpan(8, 0, 0), End = new TimeSpan(9, 0, 0), Fee = 30 }
		};

		var vehicleTollPassages = new List<TollPassage>
		{
			new TollPassage { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59) },	// Fee = 0 (next fee is higher)
			new TollPassage { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 0, 0) },	// Fee = 20
			new TollPassage { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59) },	// Fee = 0 (next fee is higher)
			new TollPassage { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 8, 0, 0) },	// Fee = 30 (only fee in interval)
			new TollPassage { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 10, 00, 00) } // Fee = 0
		};

		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalDTO>()).Returns(fakeIntervals);
		var expectedVehicleDailyFee = 50;
		var expectedPlateNumber = "ABC123";

		// Act	
		var result = _sut.GetTotalFeeForVehiclePassages(vehicleTollPassages).Result;

		// Assert
		Assert.That(result.PlateNumber, Is.EqualTo(expectedPlateNumber));
		Assert.That(result.DailyFee, Is.EqualTo(expectedVehicleDailyFee));
	}

	[Test]
	public void GetTotalFeeForVehiclePassages_WhenPassagesForDifferentVehiclesProvided_ThrowsArgumentException()
	{
		// Arrange
		var vehicleTollPassages = new List<TollPassage>
		{
			new TollPassage { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59) },
			new TollPassage { PlateNumber = "XYZ123", PassageTime = new DateTime(2025, 1, 20, 7, 0, 0) }
		};

		// Act & Assert
		Assert.ThrowsAsync<ArgumentException>(() => _sut.GetTotalFeeForVehiclePassages(vehicleTollPassages));
	}

	[Test]
	public void GetTotalFeeForVehiclePassages_WhenPassagesListIsNull_ThrowsArgumentNullException()
	{
		// Arrange
		List<TollPassage> vehicleTollPassages = null;

		// Act & Assert
		Assert.ThrowsAsync<ArgumentNullException>(() => _sut.GetTotalFeeForVehiclePassages(vehicleTollPassages));
	}

	[Test]
	public void GetTotalFeeForVehiclePassages_WhenPassagesListIsEmpty_ThrowsArgumentException()
	{
		// Arrange
		var vehicleTollPassages = new List<TollPassage>();
		// Act & Assert
		Assert.ThrowsAsync<ArgumentException>(() => _sut.GetTotalFeeForVehiclePassages(vehicleTollPassages));
	}

	[Test]
	public void GetTotalFeeForVehiclePassages_WhenDailyFeeExceedsMaxDailyFee_ReturnsMaxDailyFee()
	{
		// Arrange
		var fakeIntervals = new List<FeeIntervalDTO>
		{
			new FeeIntervalDTO { Start = new TimeSpan(6, 0, 0), End = new TimeSpan(7, 0, 0), Fee = 100 }
		};

		var vehicleTollPassages = new List<TollPassage>
		{
			new TollPassage { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0) } // Fee = 100
		};

		var expectedDailyFee = _sut.GetMaxDailyFee();
		var expectedPlateNumber = "ABC123";
		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalDTO>()).Returns(fakeIntervals);

		// Act	
		var result = _sut.GetTotalFeeForVehiclePassages(vehicleTollPassages).Result;

		// Assert
		Assert.That(result.DailyFee, Is.EqualTo(expectedDailyFee));
	}
}


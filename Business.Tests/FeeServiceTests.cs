namespace Business.Tests;

[TestFixture]
public class FeeServiceTests
{
	private IFeeService _sut;
	private IDbService _fakeDbService;
	private ITollFreeDaysService _fakeTollFreeDaysService;
	private IFeeService _fakeFeeService;

	[SetUp]
	public void SetUp()
	{
		_fakeDbService = A.Fake<IDbService>();
		_sut = new FeeService(_fakeDbService);
		_fakeTollFreeDaysService = A.Fake<ITollFreeDaysService>();
		_fakeFeeService = A.Fake<IFeeService>();
	}

	[Test]
	public void GetDailyFeeSummaryForEachVehicle_WhenValidInputProvided_ReturnsCorrectDailyFees()
	{
		// Arrange
		var fakeIntervals = new List<FeeIntervalDTO>
		{
			new FeeIntervalDTO { Start = new TimeSpan(6, 0, 0), End = new TimeSpan(7, 0, 0), Fee = 10 },
			new FeeIntervalDTO { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(8, 0, 0), Fee = 20 },
			new FeeIntervalDTO { Start = new TimeSpan(8, 0, 0), End = new TimeSpan(9, 0, 0), Fee = 30 }
		};

		var dailyTollPassages = new List<TollCameraData>
		{
			new TollCameraData { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59) },	// Fee = 0 (next fee is higher)
			new TollCameraData { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 0, 0) },	// Fee = 20
			new TollCameraData { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59) },	// Fee = 0 (next fee is higher and within 1 hour)
			new TollCameraData { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 8, 0, 0) },	// Fee = 30 (only fee in interval)
			new TollCameraData { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 10, 00, 00) },// Fee = 0
				
			new TollCameraData { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 5, 59, 59) },	// Fee = 0 (no fee in interval)
			new TollCameraData { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0) },	// Fee = 0 (next fee within 1 hour)
			new TollCameraData { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 6, 59, 59) },	// Fee = 10  
			new TollCameraData { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 7, 59, 59) },	// Fee = 0 (next fee is higher and within 1 hour)
			new TollCameraData { PlateNumber = "DEF456", PassageTime = new DateTime(2025, 1, 20, 8, 00, 00) }  // Fee = 30
		};

		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalDTO>()).Returns(fakeIntervals);

		var expectedVehicleDailyFees = new List<VehicleDailyFee>
		{
				new VehicleDailyFee() { PlateNumber = "ABC123", DailyFee = 50 },
				new VehicleDailyFee() { PlateNumber = "DEF456", DailyFee = 40 }
		};

		// Act	
		var result = _sut.GetDailyFeeSummaryForEachVehicle(dailyTollPassages).Result;

		// Assert
		Assert.That(expectedVehicleDailyFees.Zip(result, (a, b) => 
			a.PlateNumber == b.PlateNumber &&
			a.DailyFee == b.DailyFee)
			.All(x => x));
	}	

	[Test]
	public void GetDailyFeeSummaryForEachVehicle_WhenDailyFeeExceedsMaxDailyFee_ReturnsMaxDailyFee()
	{
		// Arrange
		var fakeIntervals = new List<FeeIntervalDTO>
		{
			new FeeIntervalDTO { Start = new TimeSpan(6, 0, 0), End = new TimeSpan(7, 0, 0), Fee = 100 }
		};

		var vehicleTollPassages = new List<TollCameraData>
		{
			new TollCameraData { PlateNumber = "ABC123", PassageTime = new DateTime(2025, 1, 20, 6, 0, 0) } // Fee = 100
		};

		var expectedDailyFee = _sut.GetMaxDailyFee();
		var expectedPlateNumber = "ABC123";
		A.CallTo(() => _fakeDbService.GetAsync<FeeInterval, FeeIntervalDTO>()).Returns(fakeIntervals);

		// Act	
		var result = _sut.GetDailyFeeSummaryForEachVehicle(vehicleTollPassages).Result;

		// Assert
		Assert.That(result.First().DailyFee, Is.EqualTo(expectedDailyFee));
	}
}


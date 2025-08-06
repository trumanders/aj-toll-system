namespace Business.Tests;

[TestFixture]
public class TollPassageServiceTests
{
	private ITollCameraService _sut;
	private IDbService _fakeDbService;
	private IFeeService _fakeFeeService;
	private ITollFreeDaysService _fakeTollFreeDaysService;
	private DateTime _date;
	private List<SimulatedVehicleApiDataDTOPlateNumber> _fakeVehicleInfo;
	private List<TollPassageData> _result;

	[SetUp]
	public void Setup()
	{
		_fakeDbService = A.Fake<IDbService>();
		_fakeFeeService = A.Fake<IFeeService>();
		_fakeTollFreeDaysService = A.Fake<ITollFreeDaysService>();
		_sut = new TollCameraService(_fakeDbService);
		GenerateTollPassagesForOneDay_Arrange();
	}

	[Test]
	public async Task GenerateTollPassagesForOneDay_WhenValidInputProvided_ReturnsOrderedList()
	{
		var _numberOfPassages = 100;

		// Act
		_result = await _sut.GenerateDailyTollCameraData(_date, _numberOfPassages);

		// Assert
		Assert.That(_result, Is.Ordered.By(nameof(TollPassageData.PassageTime)));
	}

	[Test]
	public async Task GenerateTollPassagesForOneDay_WhenValidInputProvided_ReturnsNonNullResult()
	{
		var _numberOfPassages = 100;

		// Act
		_result = await _sut.GenerateDailyTollCameraData(_date, _numberOfPassages);

		// Assert
		Assert.That(_result, Is.Not.Null);
	}

	[TestCase(1)]
	[TestCase(100)]
	[TestCase(1000)]
	[TestCase(1000000)]
	public async Task GenerateTollPassagesForOneDay_WhenValidInputProvided_ReturnsCorrectNumberOfPassages(int numberOfPassages)
	{
		// Act
		_result = await _sut.GenerateDailyTollCameraData(_date, numberOfPassages);

		// Assert
		Assert.That(_result, Has.Count.EqualTo(numberOfPassages));
	}

	[TestCase(1)]
	[TestCase(100)]
	[TestCase(1000)]
	[TestCase(1000000)]
	public async Task GenerateTollPassagesForOneDay_WhenValidInputProvided_ReturnsResultWithTheSameDate(int numberOfPassages)
	{
		// Act
		_result = await _sut.GenerateDailyTollCameraData(_date, numberOfPassages);

		// Assert
		Assert.That(_result.Select(x => x.PassageTime.Date).Distinct().Count(), Is.EqualTo(1));
	}

	private void GenerateTollPassagesForOneDay_Arrange()
	{
		// Arrange
		_date = DateTime.Now.Date;
		_fakeVehicleInfo =
		[
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "ABC123" },
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "DEF456" },
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "GHI789" },
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "JKL012" },
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "MNO345" }
		];

		A.CallTo((() => _fakeDbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateNumber>()))
			.Returns(_fakeVehicleInfo);
	}
}

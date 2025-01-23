namespace Business.Tests;

[TestFixture]
public class TollPassageServiceTests
{
	private ITollPassageService _sut;
	private IDbService _fakeDbService;
	private IFeeService _fakeFeeService;
	private DateTime _date;
	private List<VehicleInfoDTOPlateNumber> _fakeVehicleInfo;
	private List<TollPassage> _result;

	[SetUp]
	public void Setup()
	{
		_fakeDbService = A.Fake<IDbService>();
		_sut = new TollPassageService(_fakeDbService, _fakeFeeService);
	}

	[Test]
	public async Task GenerateTollPassagesForOneDay_WhenValidInputProvided_ReturnsOrderedList()
	{
		// Arrange
		Arrange();
		var _numberOfPassages = 100;

		// Act
		_result = await _sut.GenerateTollPassagesForOneDay(_date, _numberOfPassages);

		// Assert
		Assert.That(_result, Is.Ordered.By(nameof(TollPassage.PassageTime)));
	}

	[Test]
	public async Task GenerateTollPassagesForOneDay_WhenValidInputProvided_ReturnsNonNullResult()
	{
		// Arrange
		Arrange();
		var _numberOfPassages = 100;

		// Act
		_result = await _sut.GenerateTollPassagesForOneDay(_date, _numberOfPassages);
		
		// Assert
		Assert.That(_result, Is.Not.Null);
	}

	[TestCase(1)]
	[TestCase(100)]
	[TestCase(1000)]
	[TestCase(1000000)]
	public async Task GenerateTollPassages_WhenValidInputProvided_ReturnsCorrectNumberOfPassages(int numberOfPassages)
	{
		// Arrange
		Arrange();

		// Act
		_result = await _sut.GenerateTollPassagesForOneDay(_date, numberOfPassages);

		// Assert
		Assert.That(_result, Has.Count.EqualTo(numberOfPassages));
	}

	[TestCase(1)]
	[TestCase(100)]
	[TestCase(1000)]
	[TestCase(1000000)]
	public async Task GenerateTollPassages_WhenValidInputProvided_ReturnsResultWithTheSameDate(int numberOfPassages)
	{
		// Arrange
		Arrange();

		// Act
		_result = await _sut.GenerateTollPassagesForOneDay(_date, numberOfPassages);
		//_result.ToList().ForEach(x => Debug.WriteLine(x.PassageDate + " - " + x.PlateNumber));

		// Assert
		Assert.That(_result.Select(x => x.PassageTime.Date).Distinct().Count(),Is.EqualTo(1));
	}

	private void Arrange()
	{
		// Arrange
		_date = DateTime.Now.Date;
		_fakeVehicleInfo = new List<VehicleInfoDTOPlateNumber>
		{
			new VehicleInfoDTOPlateNumber { PlateNumber = "ABC123" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "DEF456" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "GHI789" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "JKL012" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "MNO345" }
		};

		A.CallTo(() => _fakeDbService.GetAsync<VehicleInfo, VehicleInfoDTOPlateNumber>())
			.Returns(_fakeVehicleInfo);
	}
}

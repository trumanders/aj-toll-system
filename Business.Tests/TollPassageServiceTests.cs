using FakeItEasy;

namespace Business.Tests;

[TestFixture]
public class TollPassageServiceTests
{
	private ITollPassageService _sut;
	private IDbService _fakeDbService;
	private IFeeService _fakeFeeService;
	private ITollFreeDaysService _fakeTollFreeDaysService;
	private DateTime _date;
	private List<VehicleInfoDTOPlateNumber> _fakeVehicleInfo;
	private List<TollPassage> _result;

	[SetUp]
	public void Setup()
	{
		_fakeDbService = A.Fake<IDbService>();
		_fakeFeeService = A.Fake<IFeeService>();
		_fakeTollFreeDaysService = A.Fake<ITollFreeDaysService>();
		_sut = new TollPassageService(_fakeDbService, _fakeFeeService, _fakeTollFreeDaysService);
	}

	[Test]
	public async Task GetDailyFeeSummaryForEachVehicle_WhenTollFreeDayProvided_ReturnsListWithZeroFees()
	{
		// Arrange
		var anyDate = DateTime.Now;
		var tollPassages = new List<TollPassage>
		{
			new TollPassage { PlateNumber = "ABC123", PassageTime = anyDate }
		};

		A.CallTo(() => _fakeTollFreeDaysService.IsTollFreeDay(anyDate)).Returns(true);

		// Act
		var result = await _sut.GetDailyFeeSummaryForEachVehicle(tollPassages);

		// Assert
		Assert.That(result, Is.Empty);
		A.CallTo(_fakeFeeService).MustNotHaveHappened();
	
	}

	[Test]
	public async Task GetDailyFeeSummaryForEachVehicle_WhenChargableDayProvided_ReturnsListWithCorrectFees()
	{
		// Arrange
		var anyDate = DateTime.Now;
		var tollPassages = new List<TollPassage>
		{
			new TollPassage { PlateNumber = "ABC123", PassageTime = anyDate },
			new TollPassage { PlateNumber = "ABC123", PassageTime = anyDate },
			new TollPassage { PlateNumber = "DEF456", PassageTime = anyDate },
			new TollPassage { PlateNumber = "DEF456", PassageTime = anyDate },
			new TollPassage { PlateNumber = "DEF456", PassageTime = anyDate }
		};

		var fakeVehicleDailyFee1 = new VehicleDailyFee { PlateNumber = "ABC123", DailyFee = 20 };
		var fakeVehicleDailyFee2 = new VehicleDailyFee { PlateNumber = "DEF456", DailyFee = 30 };

		A.CallTo(() => _fakeFeeService.GetTotalFeeForVehiclePassages(A<List<TollPassage>>
			.That.Matches(passages => passages.All(p => p.PlateNumber == fakeVehicleDailyFee1.PlateNumber))))
			.Returns(fakeVehicleDailyFee1);

		A.CallTo(() => _fakeFeeService.GetTotalFeeForVehiclePassages(A<List<TollPassage>>
			.That.Matches(passages => passages.All(p => p.PlateNumber == fakeVehicleDailyFee2.PlateNumber))))
			.Returns(fakeVehicleDailyFee2);

		// Act
		var result = await _sut.GetDailyFeeSummaryForEachVehicle(tollPassages);

		// Assert
		Assert.That(result, Has.Count.EqualTo(2));
		Assert.That(result, Has.Exactly(1).Matches<VehicleDailyFee>(x => x.PlateNumber == "ABC123" && x.DailyFee == 20));
		Assert.That(result, Has.Exactly(1).Matches<VehicleDailyFee>(x => x.PlateNumber == "DEF456" && x.DailyFee == 30));
	}

	[Test]
	public async Task GenerateTollPassagesForOneDay_WhenValidInputProvided_ReturnsOrderedList()
	{
		// Arrange
		GenerateTollPassagesForOneDay_Arrange();
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
		GenerateTollPassagesForOneDay_Arrange();
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
	public async Task GenerateTollPassagesForOneDay_WhenValidInputProvided_ReturnsCorrectNumberOfPassages(int numberOfPassages)
	{
		// Arrange
		GenerateTollPassagesForOneDay_Arrange();

		// Act
		_result = await _sut.GenerateTollPassagesForOneDay(_date, numberOfPassages);

		// Assert
		Assert.That(_result, Has.Count.EqualTo(numberOfPassages));
	}

	[TestCase(1)]
	[TestCase(100)]
	[TestCase(1000)]
	[TestCase(1000000)]
	public async Task GenerateTollPassagesForOneDay_WhenValidInputProvided_ReturnsResultWithTheSameDate(int numberOfPassages)
	{
		// Arrange
		GenerateTollPassagesForOneDay_Arrange();

		// Act
		_result = await _sut.GenerateTollPassagesForOneDay(_date, numberOfPassages);
		//_result.ToList().ForEach(x => Debug.WriteLine(x.PassageDate + " - " + x.PlateNumber));

		// Assert
		Assert.That(_result.Select(x => x.PassageTime.Date).Distinct().Count(),Is.EqualTo(1));
	}

	private void GenerateTollPassagesForOneDay_Arrange()
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

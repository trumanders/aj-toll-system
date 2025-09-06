using System.Data;

namespace Business.Tests;

[TestFixture]
public class TollCameraServiceTests
{
	private ITollCameraService _sut;
	private IDbService _fakeDbService;
	private DateTime _date = new DateTime(2022, 02, 02);

	private readonly List<SimulatedVehicleApiDataDTOPlateNumber> _fakeVehicleInfo =
		[
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "ABC123" },
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "DEF456" },
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "GHI789" },
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "JKL012" },
			new SimulatedVehicleApiDataDTOPlateNumber { PlateNumber = "MNO345" },
		];

	[SetUp]
	public void Setup()
	{
		_fakeDbService = A.Fake<IDbService>();
		_sut = new TollCameraService(_fakeDbService);

		A.CallTo((() => _fakeDbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateNumber>()))
			.Returns(_fakeVehicleInfo);
	}

	[Test]
	public async Task GetDailyTollCameraData_WhenValidInputProvided_ReturnsOrderedList()
	{
		var numberOfPassages = 100;

		// Act
		var result = await _sut.GetDailyTollCameraData(_date, numberOfPassages);

		// Assert
		Assert.That(result, Is.Ordered.By(nameof(TollPassageData.PassageTime)));
	}

	[Test]
	public async Task GetDailyTollCameraData_WhenValidInputProvided_ReturnsNonNullResult()
	{
		var numberOfPassages = 100;

		// Act
		var result = await _sut.GetDailyTollCameraData(_date, numberOfPassages);

		// Assert
		Assert.That(result, Is.Not.Null);
	}

	[TestCase(1)]
	[TestCase(100)]
	[TestCase(1000)]
	[TestCase(1000000)]
	public async Task GetDailyTollCameraData_WhenValidInputProvided_ReturnsCorrectNumberOfPassages(int numberOfPassages)
	{
		// Act
		var result = await _sut.GetDailyTollCameraData(_date, numberOfPassages);

		// Assert
		Assert.That(result, Has.Count.EqualTo(numberOfPassages));
	}

	[TestCase(1)]
	[TestCase(100)]
	[TestCase(1000)]
	[TestCase(1000000)]
	public async Task GetDailyTollCameraData_WhenValidInputProvided_ReturnsResultWithTheSameDate(int numberOfPassages)
	{
		// Act
		var result = await _sut.GetDailyTollCameraData(_date, numberOfPassages);

		// Assert
		Assert.That(result.Select(x => x.PassageTime.Date).Distinct().Count(), Is.EqualTo(1));
	}
}

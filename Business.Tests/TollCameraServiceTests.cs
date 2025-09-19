using System.Data;

namespace Business.Tests;

[TestFixture]
public class TollCameraServiceTests
{
	private readonly ITollCameraService _sut;
	private readonly IDbService _fakeDbService;
	private readonly DateTime _date = new(2022, 02, 02);

	private readonly List<SimulatedVehicleApiDataPlateNumber> _fakePlateNumbers =
	[
		new SimulatedVehicleApiDataPlateNumber { PlateNumber = "ABC123" },
		new SimulatedVehicleApiDataPlateNumber { PlateNumber = "DEF456" },
		new SimulatedVehicleApiDataPlateNumber { PlateNumber = "GHI789" },
		new SimulatedVehicleApiDataPlateNumber { PlateNumber = "JKL012" },
		new SimulatedVehicleApiDataPlateNumber { PlateNumber = "MNO345" },
	];

	public TollCameraServiceTests()
	{
		_fakeDbService = A.Fake<IDbService>();
		_sut = new TollCameraService(_fakeDbService);
		A.CallTo((() => _fakeDbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataPlateNumber>()))
			.Returns(_fakePlateNumbers);
	}

	[Test]
	public async Task GetDailyTollCameraData_WhenValidInputProvided_ShouldReturnOrderedList()
	{
		var numberOfPassages = 100;

		// Act
		var result = await _sut.GetDailyTollCameraData(_date, numberOfPassages);

		// Assert
		Assert.That(result, Is.Ordered.By(nameof(TollPassageData.PassageTime)));
	}

	[Test]
	public async Task GetDailyTollCameraData_WhenValidInputProvided_ShouldReturnNonNullResult()
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
	public async Task GetDailyTollCameraData_WhenValidInputProvided_ShouldReturnCorrectNumberOfPassages(int numberOfPassages)
	{
		// Act
		var result = await _sut.GetDailyTollCameraData(_date, numberOfPassages);

		// Assert
		Assert.That(result, Has.Count.EqualTo(numberOfPassages));
	}

	public async Task GetDailyTollCameraData_WhenValidInputProvided_ShouldReturnResultWithTheSameDate(int numberOfPassages)
	{
		// Act
		var result = await _sut.GetDailyTollCameraData(_date, numberOfPassages);

		// Assert
		Assert.That(result.Select(x => x.PassageTime.Date).Distinct().Count(), Is.EqualTo(1));
	}
}

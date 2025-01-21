using Business.Services;
using Persistence.Contexts;
using Persistence.Entities;
using Common.DTO;
using FakeItEasy;
using Persistence.Interfaces;
using AutoMapper.Execution;
using System.Diagnostics;
namespace Business.Tests;

[TestFixture]
public class TollPassageServiceTests
{
	private TollPassageService _sut;
	private IDbService _fakeDbService;

	[SetUp]
	public void Setup()
	{
		_fakeDbService = A.Fake<IDbService>();
		_sut = new TollPassageService(_fakeDbService);
	}

	[TestCase("2024-05-10T06:00:00", 10)]
	public async Task GenerateTollPassagesTest(DateTime date, int numberOfPassages)
	{
		// Arrange
		var fakeVehicleInfo = new List<VehicleInfoDTOPlateNumber>
		{
			new VehicleInfoDTOPlateNumber { PlateNumber = "ABC123" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "DEF456" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "GHI789" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "JKL012" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "MNO345" }
		};
		
		A.CallTo(() => _fakeDbService.GetAsync<VehicleInfo, VehicleInfoDTOPlateNumber>())
			.Returns(fakeVehicleInfo);

		var result = await _sut.GenerateTollPassages(date, numberOfPassages);

		// Assert
		Assert.That(result, Is.Not.Null);
	}
}

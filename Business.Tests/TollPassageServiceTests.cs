using Business.Services;
using Persistence.Contexts;
using Persistence.Entities;
using Common.DTO;
using FakeItEasy;
using Persistence.Interfaces;
using AutoMapper.Execution;
using System.Diagnostics;
using Business.Models;
using Microsoft.IdentityModel.Tokens;
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

	[Test]
	public async Task GenerateTollPassages_WhenValidInputProvided_ReturnsExpectedResult()
	{
		// Arrange
		var date = DateTime.Now;
		var numberOfPassages = 100;
		var fakeVehicleInfo = GetFakeVehicleInfo();	

		A.CallTo(() => _fakeDbService.GetAsync<VehicleInfo, VehicleInfoDTOPlateNumber>())
			.Returns(fakeVehicleInfo);

		var result = await _sut.GenerateTollPassages(date, numberOfPassages);

		// Assert
		Assert.That(result, Is.Not.Null);
		Assert.That(result, Is.Ordered.By(nameof(TollPassage.PassageDate)));
		Assert.That(result, Has.Count.EqualTo(numberOfPassages));
	}

	private List<VehicleInfoDTOPlateNumber> GetFakeVehicleInfo()
	{
		return new List<VehicleInfoDTOPlateNumber>
		{
			new VehicleInfoDTOPlateNumber { PlateNumber = "ABC123" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "DEF456" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "GHI789" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "JKL012" },
			new VehicleInfoDTOPlateNumber { PlateNumber = "MNO345" }
		};
	}
}

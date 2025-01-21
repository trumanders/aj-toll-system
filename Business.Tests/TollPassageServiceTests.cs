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
	private DateTime _date;
	private int _numberOfPassages;
	private List<VehicleInfoDTOPlateNumber> _fakeVehicleInfo;
	private List<TollPassage> _result;

	[SetUp]
	public void Setup()
	{
		_fakeDbService = A.Fake<IDbService>();
		_sut = new TollPassageService(_fakeDbService);
	}

	[Test]
	public async Task GenerateTollPassages_WhenValidInputProvided_ReturnsOrderedList()
	{		
		Arrange();

		// Act
		_result = await _sut.GenerateTollPassages(_date, _numberOfPassages);

		// Assert
		Assert.That(_result, Is.Ordered.By(nameof(TollPassage.PassageDate)));
	}

	[Test]
	public async Task GenerateTollPassages_WhenValidInputProvided_ReturnsNonNullResult()
	{
		// Arrange
		Arrange();
		
		// Act
		_result = await _sut.GenerateTollPassages(_date, _numberOfPassages);
		
		// Assert
		Assert.That(_result, Is.Not.Null);
	}

	[Test]
	public async Task GenerateTollPassages_WhenValidInputProvided_ReturnsCorrectNumberOfPassages()
	{
		// Arrange
		Arrange();

		// Act
		_result = await _sut.GenerateTollPassages(_date, _numberOfPassages);

		// Assert
		Assert.That(_result, Has.Count.EqualTo(_numberOfPassages));
	}

	[Test]
	public async Task GenerateTollPassages_WhenValidInputProvided_ReturnsResultWithTheSameDate()
	{
		// Arrange
		Arrange();

		// Act
		_result = await _sut.GenerateTollPassages(_date, _numberOfPassages);

		// Assert
		Assert.That(_result.Select(x => x.PassageDate.Date).Distinct().Count(),Is.EqualTo(1));
	}

	private void Arrange()
	{
		// Arrange
		_date = DateTime.Now.Date;
		_numberOfPassages = 100;
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

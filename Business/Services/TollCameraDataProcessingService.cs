using Persistence.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace Business.Services;

public class TollCameraDataProcessingService : ITollCameraDataProcessingService
{
	private readonly IDbService _dbService;
	private readonly IFeeService _feeService;
	private readonly ITollCameraService _tollCameraService;
	private readonly ITollFreeDaysService _tollFreeDaysService;

	public TollCameraDataProcessingService(IDbService dbService, ITollCameraService tollCameraService, IFeeService feeService, ITollFreeDaysService tollFreeDaysService)
	{
		_dbService = dbService;
		_tollCameraService = tollCameraService;
		_feeService = feeService;
		_tollFreeDaysService = tollFreeDaysService;
	}


	public async Task<List<MonthlyFeeDTO>> ProcessDailyTollCameraData(DateTime date, int numberOfTollPassages)
	{
		if (_tollFreeDaysService.IsTollFreeDay(date))
		{
			// return empty list
		}

		// Raw toll camera data
		var dailyTollCameraData = await _tollCameraService.SimulateDailyTollCameraData(date, numberOfTollPassages);

		if (dailyTollCameraData.Count == 0)
		{
			return new List<MonthlyFeeDTO>();
		}

		// Fetch vehicle types that are not toll free
		var nonTollFreeVehicleTypes = await _dbService.GetAsync<VehicleType, VehicleTypeDTO>(vt => !vt.IsTollFree);

		// Aggregate non toll free platenumbers
		var nonTollFreePlateNumbers = await _dbService.GetAsync<SimulatedVehicleApiData, SimulatedVehicleApiDataDTOPlateNumber>(data =>
			dailyTollCameraData.Select(x => x.PlateNumber).Contains(data.PlateNumber) &&
			nonTollFreeVehicleTypes.Select(x => x.TypeName).Contains(data.VehicleTypeName));

		var nonTollFreeCameraData = dailyTollCameraData
			.Where(x => nonTollFreePlateNumbers
				.Select(p => p.PlateNumber)
			.Contains(x.PlateNumber))
			.ToList();

		var dailyFeeForEachVehicle = await _feeService.GetDailyFeeSummaryForEachVehicle(nonTollFreeCameraData);

		/* MontlyFeeRepository */ // Vehicles that are already in monthly fee table (to update) 
		var monthlyFeesToUpdate = await _dbService.GetAsync<MonthlyFee, MonthlyFeeDTO>(entity =>
			dailyFeeForEachVehicle.Select(x => x.PlateNumber).Contains(entity.PlateNumber));

		var monthlyFeesToUpdateLookup = monthlyFeesToUpdate.ToDictionary(dto => dto.PlateNumber);

		var newMonthlyFees = new List<MonthlyFeeDTO>();

		/* Update or add MonthlyFee */
		foreach (var vehicleDailyFee in dailyFeeForEachVehicle)
		{			
			if (monthlyFeesToUpdateLookup.TryGetValue(vehicleDailyFee.PlateNumber, out var monthlyFeeDto))
			{
				monthlyFeeDto.AccumulatedFee += vehicleDailyFee.DailyFee;
				monthlyFeeDto.Date = date;
			}
			else
			{
				newMonthlyFees.Add(new MonthlyFeeDTO()
				{
					PlateNumber = vehicleDailyFee.PlateNumber,
					AccumulatedFee = vehicleDailyFee.DailyFee,
					Date = date
				});
			}
		}

		// Update Monthly Fees by plate number		
		if (monthlyFeesToUpdateLookup.Count > 0)
			await _dbService.Update<MonthlyFee, MonthlyFeeDTO>(e => monthlyFeesToUpdateLookup.Values
				.Select(dto => dto.PlateNumber)
				.Contains(e.PlateNumber), monthlyFeesToUpdateLookup.Values.ToList());		

		// Add new vehicles to monthly fees
		if (newMonthlyFees.Count > 0)
			await _dbService.AddAsync<MonthlyFee, MonthlyFeeDTO>(newMonthlyFees);

		await _dbService.SaveChangesAsync();

		var updatedMonthlyFees = await _dbService.GetAsync<MonthlyFee, MonthlyFeeDTO>();

		return updatedMonthlyFees;
	}
}

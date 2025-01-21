//using TollFeeCalculatorV2.Interfaces;
//namespace Business.Services
//{
//	public class VehicleManager : IVehicleService
//	{
//		private readonly List<Vehicle> _vehicles;
//		private readonly IFeeService _feeCalculator;
//		private readonly IDateTimeService _dateManager;
//		private readonly IVehicleDataOutput _vehicleDataOutput;

//		public VehicleManager(List<Vehicle> vehicles, IFeeService feeCalculator, IDateTimeService dateManager, IVehicleDataOutput vehicleDataOutput)
//		{
//			_vehicles = vehicles ?? throw new ArgumentNullException(nameof(vehicles));
//			_feeCalculator = feeCalculator ?? throw new ArgumentNullException(nameof(feeCalculator));
//			_dateManager = dateManager ?? throw new ArgumentNullException(nameof(dateManager));
//			_vehicleDataOutput = vehicleDataOutput ?? throw new ArgumentNullException(nameof(vehicleDataOutput));
//		}

//		public void DisplayTollFeesForAllVehicles()
//		{
//			foreach (var vehicle in _vehicles)
//			{
//				_vehicleDataOutput.DisplayTollFees(vehicle, _feeCalculator.GetTotalFeeForPassages(vehicle.TollPassages));
//			}
//		}

//		// Flytta till en TollPassageService, där man stoppar in en fordonstyp och får
//		// tillbaka en lista med passager, som man lägger i vehicle-objektet.
//		public void GenerateNewTollPassagesForAllVehicles(int numberOfPassages, TimeSpan timeSpan)
//		{
//			if (timeSpan <= TimeSpan.Zero || numberOfPassages < 1)
//				return;

//			foreach (var vehicle in _vehicles)
//			{
//				if (IsTollFreeTypes(vehicle.Types))
//				{
//					continue;
//				}

//				vehicle.TollPassages.Clear();

//				// lista med datum/tid
//				var newDates = _dateManager.GetRandomDates(numberOfPassages, timeSpan);

//				// varje datum/tid i listan blir en ny passage för aktuella fordonet
//				foreach (var date in newDates)
//				{
//					// lägg till varje passage i fordonets lista, lägg till avgift
//					// oberoende om den ska betalas eller inte, eftersom man behöver 
//					// ha alla avgifter för att see vilka som ska betalas (högst avgift inom en timme)
//					vehicle.TollPassages.Add(new TollPassage(date, _feeCalculator.GetFeeByDate(date)));
//				}

//				// när alla passager med avgift är tillagda, beräkna vilka som ska betalas				
//				_feeCalculator.CalculateFeeDue(vehicle.TollPassages);
//			}
//		}

//		public bool IsTollFreeTypes(VehicleTypes types)
//		{
//			return VehicleTypesManager.GetTollFreeVehicleTypes()
//				.Any(tollFreeType => types.HasFlag(tollFreeType));
//		}
//	}
//}

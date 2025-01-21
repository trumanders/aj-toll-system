//using TollFeeCalculatorV2.Interfaces;
//namespace Business.Services;

//public class FeeService : IFeeService
//{
//	ITollRateService _tollRateProvider;

//	const int MAX_FEE = 60;
//	static readonly TimeSpan _singleChargeInterval = TimeSpan.FromHours(1);

//	public FeeService(ITollRateService tollRateProvider)
//	{
//		_tollRateProvider = tollRateProvider ?? throw new ArgumentNullException(nameof(tollRateProvider));
//	}

//	private bool IsTollFreeDate(DateTime date)
//	{
//		if (date.Year != 2024)
//			throw new NotImplementedException();

//		// All saturdays and sundays, and july are toll-free
//		if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || _config.TollFreeMonths.Contains(date.Month))
//			return true;

//		return _config.Holidays.Contains(date.Date) || _config.Holidays.Contains(date.Date.AddDays(1));
//	}

//	public int GetTollRate(DateTime dateTime)
//	{
//		if (IsTollFreeDate(dateTime))
//			return 0;

//		TimeSpan time = dateTime.TimeOfDay;

//		// För varje avgiftsnivå i config-filen
//		foreach (var tollFee in _config.TollFees)
//		{
//			// gå igenom varje intervall som avgiften gäller för
//			foreach (var interval in tollFee.TimeIntervals)
//			{
//				// om inskickad tid finns i intevallet -> returnera avgiften
//				if (time >= interval.Start && time < interval.End)
//				{
//					return tollFee.Fee;
//				}
//			}
//		}

//		return _config.DefaultFee;
//	}

//	public void CalculateFeeDue(List<TollPassage> tollPassages)
//	{
//		if (tollPassages == null)
//			throw new ArgumentNullException(nameof(tollPassages), "Toll passages list cannot be null.");

//		if (tollPassages.Count == 0)
//			throw new ArgumentException("Toll passages list cannot be empty.", nameof(tollPassages));

//		var firstFeePassage = tollPassages.FirstOrDefault(passage => passage.Fee > 0)
//			?? tollPassages.First();

//		var intervalStart = firstFeePassage.PassageTime;
//		var highestFeePassageInInterval = firstFeePassage;

//		foreach (var tollPassage in tollPassages)
//		{
//			// Kollar om vi är inom en timme från intervallets start
//			if (IsPassageWithinInterval(intervalStart, tollPassage.PassageTime, _singleChargeInterval))
//			{
//				// om vi är inom en timma, sätt nuvarande passage till den med högst avgift
//				// om den är högre än rådande högsta avgift
//				if (tollPassage.Fee > highestFeePassageInInterval.Fee)
//				{
//					highestFeePassageInInterval = tollPassage;
//				}
//				tollPassage.Fee = 0;
//			}
//			else // om vi är förbi en timme...
//			{
//				// sätt första passagen i nya intervallet som högsta avgift
//				highestFeePassageInInterval = tollPassage;

//				// sätt denna första passagen till intervallets start
//				intervalStart = tollPassage.PassageTime;
//			}
//		}
//		// Om sista passagen påbörjar ett nytt intervall, sätt avgift på den.
//		//highestFeePassageInInterval.IsFeeToPay = highestFeePassageInInterval.Fee > 0;
//	}

//	public int GetFeeByDate(DateTime date)
//	{
//		return _tollRateProvider.GetTollRate(date);
//	}

//	public int GetTotalFeeForPassages(List<TollPassage> tollPassages)
//	{
//		var totalFee = tollPassages
//			.GroupBy(passage => passage.PassageTime.Date)
//			.Sum(group => Math.Min(group.Sum(passage => passage.Fee), MAX_FEE));
//		// obs, returnerar inte avgiften för en dag
//		// om datumen går över flera dagar, gruperas avgiften per dag, och maximeras till 60kr
//		// för varje dag. Om passagerna går över tex 2 dagar, varav en överstiger 60kr och en 
//		// är på 40kr, returneras 60 + 40.
//		return totalFee;
//	}

//	private bool IsPassageWithinInterval(DateTime start, DateTime end, TimeSpan timeSpan)
//	{
//		return end - start < timeSpan;
//	}
//}
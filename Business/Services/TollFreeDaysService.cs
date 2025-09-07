namespace Business.Services;

public class TollFreeDaysService : ITollFreeDaysService
{
	private readonly IPublicHolidays _holiday;
	private const int DAY_AFTER = 1;

	public TollFreeDaysService(IPublicHolidays holiday)
	{
		_holiday = holiday;
	}

	// Toll free dates include Saturdays, Sundays, public holidays, and the day before a public holiday
	public bool IsTollFreeDay(DateTime date)
	{
		bool isTollFreeDay =
			date.DayOfWeek == DayOfWeek.Saturday
			|| date.DayOfWeek == DayOfWeek.Sunday
			|| date.Month == 7
			|| _holiday.IsPublicHoliday(date)
			|| _holiday.IsPublicHoliday(date.AddDays(DAY_AFTER));

		return isTollFreeDay;
	}
}

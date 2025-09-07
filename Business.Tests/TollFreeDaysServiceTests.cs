namespace Business.Tests;

[TestFixture]
public class TollFreeDaysServiceTests
{
	private ITollFreeDaysService _sut;
	private IPublicHolidays _fakePublicHolidays;

	[SetUp]
	public void Setup()
	{
		_fakePublicHolidays = A.Fake<IPublicHolidays>();
		_sut = new TollFreeDaysService(_fakePublicHolidays);
	}

	[Test]
	public void IsTollFreeDay_WhenHolidayProvided_ShouldReturnTrue()
	{
		var holiday = new DateTime(2024, 1, 1);
		var dayBeforeHoliday = holiday.AddDays(-1);
		var saturday = new DateTime(2025, 1, 18);
		var sunday = new DateTime(2025, 1, 19);
		var july = new DateTime(2025, 7, 1);

		// Return false for anything but holidays to test the logic that
		// a toll free day is a holiday, day before holiday, Saturday, Sunday, and all days of July.
		A.CallTo(() => _fakePublicHolidays.IsPublicHoliday(holiday)).Returns(true);
		A.CallTo(() => _fakePublicHolidays.IsPublicHoliday(dayBeforeHoliday)).Returns(false);
		A.CallTo(() => _fakePublicHolidays.IsPublicHoliday(saturday)).Returns(false);
		A.CallTo(() => _fakePublicHolidays.IsPublicHoliday(sunday)).Returns(false);
		A.CallTo(() => _fakePublicHolidays.IsPublicHoliday(july)).Returns(false);

		Assert.That(_sut.IsTollFreeDay(holiday), Is.True);
		Assert.That(_sut.IsTollFreeDay(dayBeforeHoliday), Is.True);
		Assert.That(_sut.IsTollFreeDay(saturday), Is.True);
		Assert.That(_sut.IsTollFreeDay(sunday), Is.True);
		Assert.That(_sut.IsTollFreeDay(july), Is.True);
	}

	[Test]
	public void IsTollFreeDay_WhenChargeableDayProvided_ShouldReturnFalse()
	{
		var chargeableDayAferHoliday = new DateTime(2025, 1, 2);
		var chargeableDayTwoDaysBeforeHoliday = new DateTime(2025, 12, 30);
		var chargeableFriday = new DateTime(2025, 1, 3);
		var chargeableMonday = new DateTime(2025, 1, 6);

		A.CallTo(() => _fakePublicHolidays.IsPublicHoliday(chargeableDayAferHoliday))
			.Returns(false);
		A.CallTo(() => _fakePublicHolidays.IsPublicHoliday(chargeableDayTwoDaysBeforeHoliday))
			.Returns(false);
		A.CallTo(() => _fakePublicHolidays.IsPublicHoliday(chargeableFriday)).Returns(false);
		A.CallTo(() => _fakePublicHolidays.IsPublicHoliday(chargeableMonday)).Returns(false);

		Assert.That(_sut.IsTollFreeDay(chargeableDayAferHoliday), Is.False);
		Assert.That(_sut.IsTollFreeDay(chargeableDayTwoDaysBeforeHoliday), Is.False);
		Assert.That(_sut.IsTollFreeDay(chargeableFriday), Is.False);
		Assert.That(_sut.IsTollFreeDay(chargeableMonday), Is.False);
	}
}

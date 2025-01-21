namespace TollFeeCalculatorV2.Interfaces
{
    public interface IDateTimeService
    {
        List<DateTime> GetRandomDates(int numberOfDates, TimeSpan timeSpan);
    }
}
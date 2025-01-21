namespace TollFeeCalculatorV2.Interfaces
{
    public interface IVehicleService
    {
        //bool IsTollFreeTypes(VehicleTypes types);
        void GenerateNewTollPassagesForAllVehicles(int numberOfPassages, TimeSpan timeSpan);
		void DisplayTollFeesForAllVehicles();
	}
}
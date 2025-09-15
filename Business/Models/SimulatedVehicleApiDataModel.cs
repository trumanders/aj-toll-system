namespace Business.Models;

public class SimulatedVehicleApiDataModel : IBusinessModel
{
	public string PlateNumber { get; set; }
	public string? VehicleTypeName { get; set; }
	public string OwnerName { get; set; }
	public string OwnerStreetName { get; set; }
	public string OwnerZipCode { get; set; }
	public string OwnerCity { get; set; }
	public string OwnerCountry { get; set; }
}

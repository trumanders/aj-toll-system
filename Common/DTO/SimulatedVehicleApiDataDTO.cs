namespace Common.DTO;

public class SimulatedVehicleApiDataDTO
{
	public string PlateNumber { get; set; }
	public string OwnerName { get; set; }
	public virtual VehicleTypeDTO VehicleType { get; set; }
}

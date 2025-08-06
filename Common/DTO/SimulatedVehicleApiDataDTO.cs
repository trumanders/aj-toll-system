namespace Common.DTO;

public class SimulatedVehicleApiDataDTO
{
	public string PlateNumber { get; set; }
	public string OwnerName { get; set; }
	public int VehicleTypeId { get; set; }
	public VehicleTypeDTO? VehicleType { get; set; }
}

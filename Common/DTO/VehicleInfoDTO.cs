namespace Common.DTO;

public class VehicleInfoDTO
{
	public string PlateNumber { get; set; }
	public string OwnerName { get; set; }
	public virtual VehicleTypeDTO VehicleType { get; set; }
}

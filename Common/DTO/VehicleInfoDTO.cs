using System.ComponentModel.DataAnnotations;

namespace Common.DTO;

public class VehicleInfoDTO
{
	public int Id { get; set; }
	public string PlateNumber { get; set; }
	public string OwnerName { get; set; }
	public string VehicleTypeName { get; set; }
}

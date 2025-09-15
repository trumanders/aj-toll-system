namespace Business.Mapping;

using AutoMapper;

public class BusinessMappingProfile : Profile
{
	public BusinessMappingProfile()
	{
		CreateMap<FeeInterval, FeeIntervalModel>();
		CreateMap<SimulatedVehicleApiData, SimulatedVehicleApiDataPlateNumber>();
		CreateMap<SimulatedVehicleApiData, SimulatedVehicleApiDataPlateAndType>();
		CreateMap<VehicleType, VehicleTypeModel>();
		CreateMap<VehicleDailyFee, DailyFees>().ReverseMap();
	}
}

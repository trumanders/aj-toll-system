namespace Api.Mapping;

using Api.Dto;

public class DtoMappingProfile : Profile
{
	public DtoMappingProfile()
	{
		CreateMap<TollCameraData, TollCameraDataDto>().ReverseMap();
		CreateMap<TollPassageData, TollPassageDataDto>().ReverseMap();
		CreateMap<VehicleDailyFee, DailyFeeDto>();
	}
}

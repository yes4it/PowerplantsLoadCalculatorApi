using AutoMapper;
using GemBAL.Model;
using PowerplantsLoadCalculatorApi.Model;

namespace PowerplantsLoadCalculatorApi.Mapper
{
    public class MapperConfigProfile : Profile
    {
        public MapperConfigProfile()
        {
            CreateMap<Payload,PayloadDto>();
            CreateMap<Fuels, FuelDto>();
            CreateMap<Powerplant, PowerplantDto>();
            CreateMap<PowerplantDto, Powerplant>();
        }
    }
}

using AutoMapper;
using GemBAL.Model;
using GemDomain.Entities;
using Fuels = PowerplantsLoadCalculatorApi.Model.Fuels;
using Payload = PowerplantsLoadCalculatorApi.Model.Payload;

namespace PowerplantsLoadCalculatorApi.Mapper
{
    public class MapperConfigProfile : Profile
    {
        public MapperConfigProfile()
        {
            CreateMap<Payload, GemDomain.Entities.Payload>();
            CreateMap<Fuels, FuelDto>();
            CreateMap<PowerProductionDto, PowerProduction>();
            CreateMap<PowerProduction, PowerProductionDto>();
            CreateMap<Powerplant, PowerplantDto>();
            CreateMap<PowerplantDto, Powerplant>();

        }
    }
}

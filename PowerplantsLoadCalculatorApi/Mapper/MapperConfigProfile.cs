using AutoMapper;
using PowerplantsLoadCalculatorApi.Model;

namespace PowerplantsLoadCalculatorApi.Mapper
{
    public class MapperConfigProfile : Profile
    {
        public MapperConfigProfile()
        {
            CreateMap<Payload, GemDomain.Entities.Payload>();
            CreateMap<Fuels, GemDomain.Entities.Fuels>();
        }
    }
}

using AutoMapper;
using GemBAL.Model;
using GemBAL.Interface;
using GemDomain.Entities;
using PowerplantsLoadCalculatorApi.Interface;
using PowerplantsLoadCalculatorApi.Model;

namespace PowerplantsLoadCalculatorApi.Service
{
    public class PayloadService : IPayloadService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly ILoadCalculatorStrategyFactory _strategyFactory;

        public PayloadService(IServiceProvider serviceProvider, IMapper mapper, ILoadCalculatorStrategyFactory strategyFactory)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
            _strategyFactory = strategyFactory;
        }

        public List<PayloadResponse> GetProductionPlan(Model.Payload payload)
        {
            var powerProductions = new List<PowerProduction>();
            var cheaperPowerProductions = new List<PowerProduction>();

            var loadouput = 0d;

            payload.PowerPlants = payload.PowerPlants.OrderByDescending(x => x.Efficiency).ToList();
            var fuel = _mapper.Map<FuelDto>(payload.Fuels);

            while (payload.PowerPlants.Any())
            {
                var loadtemp = payload.Load - loadouput;
                foreach (var item in payload.PowerPlants)
                {
                    var powerGenerated = _strategyFactory.GetStrategy(item.Type).CalculatePowerProduction(_mapper.Map<PowerplantDto>(item), loadtemp, fuel);
                    powerProductions.Add(_mapper.Map<PowerProduction>(powerGenerated));
                }
                var cheaperPowerPlants = powerProductions.OrderBy(x => x.Cost / (x.Power * x.Powerplant.Efficiency)).First();

                loadouput += cheaperPowerPlants.Power;

                cheaperPowerProductions.Add(cheaperPowerPlants);

                powerProductions.Clear();
                payload.PowerPlants.Remove(cheaperPowerPlants.Powerplant);
            }

            var result = cheaperPowerProductions.Select(x => new { key = x.Powerplant.Name, p = x.Power }).ToList();
            var groupedData = result.GroupBy(x => x.key);
            var reduceData = groupedData.Select(g => new { name = g.Key, p = g.Sum(p => p.p) });

            var PayloadResponse = new List<PayloadResponse>();
            foreach (var item in reduceData)
            {
                PayloadResponse.Add(new PayloadResponse { Name = item.name.ToString(), P = item.p });
            }
            return PayloadResponse;
        }
    }
}
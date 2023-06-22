using GemBAL.Model;
using GemBAL.Interface;

namespace GemBAL.Service
{
    public class PayloadService : IPayloadService
    {
        private readonly ILoadCalculatorStrategyFactory _strategyFactory;

        public PayloadService(ILoadCalculatorStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public List<PayloadResponseDto> GetProductionPlan(PayloadDto payload)
        {
            var powerProductions = new List<PowerProductionDto>();
            var cheaperPowerProductions = new List<PowerProductionDto>();

            var loadOuput = 0d;

            payload.PowerPlants = payload.PowerPlants.OrderByDescending(x => x.Efficiency).ToList();

            while (payload.PowerPlants.Any())
            {
                var loadtemp = payload.Load - loadOuput;
                foreach (var item in payload.PowerPlants)
                {
                    var powerGenerated = _strategyFactory.GetStrategy(item.Type).CalculatePowerProduction(item, loadtemp, payload.Fuels);
                    powerProductions.Add(powerGenerated);
                }

                //take powerplant with lower cost and max efficiency
                var cheaperPowerPlants = powerProductions.OrderBy(x => x.Cost / (x.Power * x.Powerplant.Efficiency)).First();

                loadOuput += cheaperPowerPlants.Power;

                cheaperPowerProductions.Add(cheaperPowerPlants);
                powerProductions.Clear();

                //mapped object are not equals, to fix it, must override equal & gethashcode
                var powerPlantToRemove = payload.PowerPlants.FirstOrDefault(x => x.Name == cheaperPowerPlants.Powerplant.Name);
                if (powerPlantToRemove != null)
                {
                    payload.PowerPlants.Remove(powerPlantToRemove);
                }
            }


            //Map
            var result = cheaperPowerProductions.Select(x => new { key = x.Powerplant.Name, power = x.Power }).ToList();
            var groupedData = result.GroupBy(x => x.key);
            //Reduce
            var reducedData = groupedData.Select(g => new { name = g.Key, p = g.Sum(p => p.power) });

            var energyDelivered = new List<PayloadResponseDto>();
            foreach (var item in reducedData)
            {
                energyDelivered.Add(new PayloadResponseDto { Name = item.name, P = Math.Round(item.p, 1) });
            }
            return energyDelivered;
        }
    }
}
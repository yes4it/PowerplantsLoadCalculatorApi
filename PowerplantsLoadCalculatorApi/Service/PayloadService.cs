using GemBAL.Interface;
using GemDomain.Entities;

namespace PowerplantsLoadCalculatorApi.Manager
{
    public class PayloadService : IPayloadService
    {
        private readonly IServiceProvider _serviceProvider;

        public PayloadService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<PowerProduction> GetProductionPlan(Payload payload)
        {
            var allStrategies = _serviceProvider.GetServices<ILoadCalculatorStrategy>();
            var gasStrategy = allStrategies.First(s => s.PowerPlantType == GemDomain.Enum.PowerPlantType.gasfired);
            
            var powerProductions = new List<PowerProduction>();
            foreach (var item in payload.PowerPlants){
                powerProductions.Add(gasStrategy.CalculatePowerProduction(item, payload.Load, payload.Fuels));
            }
            return powerProductions;
        }
    }
}
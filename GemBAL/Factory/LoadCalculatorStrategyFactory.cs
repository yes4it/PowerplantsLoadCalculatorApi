using GemBAL.Interface;
using GemBAL.Strategy;
using GemDomain.Enum;

namespace GemBAL.Factory
{
    public class LoadCalculatorStrategyFactory : ILoadCalculatorStrategyFactory
    {
        private List<ILoadCalculatorStrategy> _strategies;

        public LoadCalculatorStrategyFactory()
        {
            _strategies = new List<ILoadCalculatorStrategy>();
        }

        public void AddStrategy(ILoadCalculatorStrategy strategy)
        {
            _strategies.Add(strategy);
        }

        public ILoadCalculatorStrategy GetStrategy(PowerPlantType powerPlantType)
        {
            switch (powerPlantType)
            {
                case PowerPlantType.gasfired:
                    return _strategies.First(s=>s.PowerPlantType == PowerPlantType.gasfired);
                case PowerPlantType.turbojet:
                    return _strategies.First(s => s.PowerPlantType == PowerPlantType.turbojet);
                case PowerPlantType.windturbine:
                    return _strategies.First(s => s.PowerPlantType == PowerPlantType.windturbine);
                default:
                    throw new NotSupportedException($"Powerplant type '{powerPlantType}' is not found.");
            }
        }
    }
}

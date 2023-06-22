using GemDomain.Enum;

namespace GemBAL.Interface
{
    public interface ILoadCalculatorStrategyFactory
    {
        ILoadCalculatorStrategy GetStrategy(PowerPlantType powerPlantType);

    }
}

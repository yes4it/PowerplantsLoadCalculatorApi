using GemDomain.Entities;
using GemDomain.Enum;

namespace GemBAL.Interface
{
    public interface ILoadCalculatorStrategy
    {
        PowerPlantType PowerPlantType { get; }
        PowerProduction CalculatePowerProduction(Powerplant powerPlant, double load, Fuels fuel);
    }
}

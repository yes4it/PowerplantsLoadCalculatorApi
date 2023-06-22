using GemBAL.Model;
using GemDomain.Enum;

namespace GemBAL.Interface
{
    public interface ILoadCalculatorStrategy
    {
        PowerPlantType PowerPlantType { get; }
        PowerProductionDto CalculatePowerProduction(PowerplantDto powerPlant, double load, FuelDto fuel);
    }
}

using GemBAL.Interface;
using GemDomain.Entities;
using GemDomain.Enum;

namespace GemBAL.Strategy
{
    public class TurbojetPowerPlantStrategy : ILoadCalculatorStrategy
    {
        public PowerPlantType PowerPlantType => throw new NotImplementedException();

        public PowerProduction CalculatePowerProduction(Powerplant powerPlant, double load, Fuels fuel)
        {
            throw new NotImplementedException();
        }
    }
}

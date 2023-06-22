using GemBAL.Model;
using GemBAL.Interface;
using GemDomain.Enum;

namespace GemBAL.Strategy
{
    public class GasFiredPowerPlantStrategy : ILoadCalculatorStrategy
    {
        public PowerPlantType PowerPlantType => PowerPlantType.gasfired;

        public PowerProductionDto CalculatePowerProduction(PowerplantDto powerPlant, double load, FuelDto fuels)
        {
            var price = fuels.Gas;

            var powerToGenerate = (load >= powerPlant.Pmax) ? powerPlant.Pmax : load;

            var fuelConsumption = powerToGenerate / powerPlant.Efficiency;
            var cost = fuelConsumption * price;

            return new PowerProductionDto(powerPlant, powerToGenerate, cost);
        }
    }
}

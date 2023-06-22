using GemBAL.Interface;
using GemBAL.Model;
using GemDomain.Entities;
using GemDomain.Enum;

namespace GemBAL.Strategy
{
    public class TurbojetPowerPlantStrategy : ILoadCalculatorStrategy
    {
        public PowerPlantType PowerPlantType => PowerPlantType.turbojet;

        public PowerProductionDto CalculatePowerProduction(PowerplantDto powerPlant, double load, FuelDto fuels)
        {
            var price = fuels.Kerosine;

            var powerToGenerate = (load >= powerPlant.Pmax) ? powerPlant.Pmax : load;

            var fuelConsumption = powerToGenerate / powerPlant.Efficiency;
            var cost = fuelConsumption * price;

            return new PowerProductionDto(powerPlant, powerToGenerate, cost);
        }
    }
}

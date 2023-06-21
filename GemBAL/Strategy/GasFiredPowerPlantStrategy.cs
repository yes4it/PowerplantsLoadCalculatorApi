using GemBAL.Interface;
using GemDomain.Entities;
using GemDomain.Enum;

namespace GemBAL.Strategy
{
    public class GasFiredPowerPlantStrategy : ILoadCalculatorStrategy
    {
        public PowerPlantType PowerPlantType => PowerPlantType.gasfired;

        public PowerProduction CalculatePowerProduction(Powerplant powerPlant, double load, Fuels fuels)
        {
            var gasPrice = fuels.Gas;

            var maxPowerProduction = load > powerPlant.Pmax ? powerPlant.Pmax : load;
            var minPowerProduction = maxPowerProduction > powerPlant.Pmin? powerPlant.Pmin : maxPowerProduction;


            var fuelConsumption = maxPowerProduction / powerPlant.Efficiency;
            var cost = fuelConsumption * gasPrice;

            return new PowerProduction(powerPlant, minPowerProduction, cost);
        }
    }
}

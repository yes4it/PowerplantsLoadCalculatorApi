using GemBAL.Model;
using GemBAL.Interface;
using GemDomain.Enum;

namespace GemBAL.Strategy
{
    public class WindTurbinePowerPlantStrategy : ILoadCalculatorStrategy
    {
        public PowerPlantType PowerPlantType => PowerPlantType.windturbine;

        public PowerProductionDto CalculatePowerProduction(PowerplantDto powerPlant, double load, FuelDto fuels)
        {
            var maxPowerOutput = Math.Min(load, powerPlant.Pmax);

            var powerOutput = maxPowerOutput * (fuels.Wind / 100.0);

            return new PowerProductionDto(powerPlant, powerOutput, 0);
        }
    }
}

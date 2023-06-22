namespace GemBAL.Model
{
    public class PowerProductionDto
    {
        public PowerplantDto Powerplant { get; }
        public double Power { get; }
        public double Cost { get; }

        public PowerProductionDto(PowerplantDto powerPlant, double power, double cost)
        {
            Powerplant = powerPlant;
            Power = power;
            Cost = cost;
        }
    }
}

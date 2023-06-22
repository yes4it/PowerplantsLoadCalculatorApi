namespace GemDomain.Entities
{
    public class PowerProduction
    {
        public Powerplant Powerplant { get; }
        public double Power { get; }
        public double Cost { get; }

        public PowerProduction(Powerplant powerPlant, double power, double cost)
        {
            Powerplant = powerPlant;
            Power = power;
            Cost = cost;
        }
    }
}

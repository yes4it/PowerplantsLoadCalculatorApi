using GemDomain.Enum;

namespace GemDomain.Entities
{
    public class Powerplant
    {
        public string Name { get; set; }
        public PowerPlantType Type { get; set; }
        public double Efficiency { get; set; }
        public double Pmax { get; set; }
        public double Pmin { get; set; }

    }
}
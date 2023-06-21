namespace GemDomain.Entities
{
    public class Payload
    {
        public double Load { get; set; }
        public Fuels Fuels { get; set; }
        public List<Powerplant> PowerPlants { get; set; }

    }
}

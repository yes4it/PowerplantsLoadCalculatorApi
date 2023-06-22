namespace GemBAL.Model
{
    public class PayloadDto
    {
        public double Load { get; set; }
        public FuelDto Fuels { get; set; }
        public List<PowerplantDto> PowerPlants { get; set; }

    }
}

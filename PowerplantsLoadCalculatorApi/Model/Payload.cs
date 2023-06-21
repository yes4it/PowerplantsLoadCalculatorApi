using GemDomain.Entities;
using Newtonsoft.Json;

namespace PowerplantsLoadCalculatorApi.Model
{
    public class Payload
    {
        public double Load { get; set; }
        [JsonRequired]
        public Fuels Fuels { get; set; }
        public List<Powerplant> PowerPlants { get; set; }

    }
}

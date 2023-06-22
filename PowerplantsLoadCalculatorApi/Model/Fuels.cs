﻿using Newtonsoft.Json;

namespace PowerplantsLoadCalculatorApi.Model
{
    [JsonObject]
    public class Fuels
    {
        [JsonProperty("gas(euro/MWh)")]
        public double Gas { get; set; }

        [JsonProperty("kerosine(euro/MWh)")]
        public double Kerosine { get; set; }

        [JsonProperty("co2(euro/ton)")]
        public int Co2 { get; set; }

        [JsonProperty("wind(%)")]
        public int Wind { get; set; }
    }
}

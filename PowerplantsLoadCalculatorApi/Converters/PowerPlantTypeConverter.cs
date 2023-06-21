using GemDomain.Enum;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PowerplantsLoadCalculatorApi.Converters
{
    public class PowerPlantTypeConverter : JsonConverter<PowerPlantType>
    {
        public override PowerPlantType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string value = reader.GetString();
                if (Enum.TryParse(value, out PowerPlantType powerPlantType))
                {
                    return powerPlantType;
                }
            }

            throw new JsonException($"Unable to convert value '{reader.GetString()}' to PowerPlantType.");
        }

        public override void Write(Utf8JsonWriter writer, PowerPlantType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}

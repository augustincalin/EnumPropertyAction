using System;
using System.Formats.Asn1;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EPA.API.Validation
{
    public class JsonEnumConverter<T> : JsonConverter<T> where T : Enum
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // this can be done better with TryParse
            string enumValue = reader.GetString() ?? string.Empty;
            return !Enum.IsDefined(typeof(T), enumValue) ? default : (T)Enum.Parse(typeof(T), enumValue);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            // Serialize the enum value as a string
            writer.WriteStringValue(value.ToString());
        }
    }
}

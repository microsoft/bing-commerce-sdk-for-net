namespace Microsoft.Bing.ECommerce.Search
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

    internal class DerivedSchemaJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return SchemaTypes.DerivedTypes.ContainsKey(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var derivedTypeMap = SchemaTypes.DerivedTypes[objectType];

            // Deserializing into a JObject then converting with ToObject does not add substantial latency and vastly
            // simplifies getting _type reliably
            var jObject = serializer.Deserialize<JObject>(reader);
            if (jObject == null)
            {
                return null;
            }

            var schemaName = jObject.Value<string>("_type");

            if (schemaName == null
                || !derivedTypeMap.TryGetValue(schemaName, out var derivedType)
                || derivedType == objectType)
            {
                if (SchemaTypes.Constructors.TryGetValue(objectType, out var ctor))
                {
                    var result = ctor();
                    serializer.Populate(jObject.CreateReader(), result);
                    return result;
                }

                // SchemaTypes should be ensuring we never get here by correctly populating Constructors
                throw new JsonSerializationException("Unable to create object of type " + objectType.FullName);
            }

            return jObject.ToObject(derivedType, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

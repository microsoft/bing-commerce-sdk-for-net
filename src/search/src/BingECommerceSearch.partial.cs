namespace Microsoft.Bing.ECommerce.Search
{
    public partial class BingECommerceSearch
    {
        partial void CustomInitialize()
        {
            // AutoRest's contract resolver is improperly recreated every time and therefore does not cache its or
            // JSON.NET's reflection, adding ~20ms each to serialization and deserialization.
            this.SerializationSettings.ContractResolver = null;
            this.DeserializationSettings.ContractResolver = null;

            // AutoRest's polymorphic JSON converters also don't correctly deserialize type discriminators
            this.DeserializationSettings.Converters.Clear();
            this.DeserializationSettings.Converters.Add(new DerivedSchemaJsonConverter());
        }
    }
}

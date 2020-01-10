// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.Commerce.Ingestion.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ResponsePushStatus.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResponsePushStatus
    {
        [EnumMember(Value = "Queued")]
        Queued,
        [EnumMember(Value = "Error")]
        Error
    }
    internal static class ResponsePushStatusEnumExtension
    {
        internal static string ToSerializedValue(this ResponsePushStatus? value)
        {
            return value == null ? null : ((ResponsePushStatus)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this ResponsePushStatus value)
        {
            switch( value )
            {
                case ResponsePushStatus.Queued:
                    return "Queued";
                case ResponsePushStatus.Error:
                    return "Error";
            }
            return null;
        }

        internal static ResponsePushStatus? ParseResponsePushStatus(this string value)
        {
            switch( value )
            {
                case "Queued":
                    return ResponsePushStatus.Queued;
                case "Error":
                    return ResponsePushStatus.Error;
            }
            return null;
        }
    }
}

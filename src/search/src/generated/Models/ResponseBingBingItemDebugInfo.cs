// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ECommerce.Search.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("BingItemDebugInfo")]
    public partial class ResponseBingBingItemDebugInfo : ResponseDebugInfo
    {
        /// <summary>
        /// Initializes a new instance of the ResponseBingBingItemDebugInfo
        /// class.
        /// </summary>
        public ResponseBingBingItemDebugInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ResponseBingBingItemDebugInfo
        /// class.
        /// </summary>
        public ResponseBingBingItemDebugInfo(IList<ResponseBingMatchingStream> perfectMatchingStreams = default(IList<ResponseBingMatchingStream>), IList<ResponseBingMatchingStream> completeMatchingStreams = default(IList<ResponseBingMatchingStream>))
        {
            PerfectMatchingStreams = perfectMatchingStreams;
            CompleteMatchingStreams = completeMatchingStreams;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "perfectMatchingStreams")]
        public IList<ResponseBingMatchingStream> PerfectMatchingStreams { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "completeMatchingStreams")]
        public IList<ResponseBingMatchingStream> CompleteMatchingStreams { get; set; }

    }
}

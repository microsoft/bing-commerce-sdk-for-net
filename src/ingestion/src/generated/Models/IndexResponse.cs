// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ECommerce.Ingestion.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class IndexResponse
    {
        /// <summary>
        /// Initializes a new instance of the IndexResponse class.
        /// </summary>
        public IndexResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IndexResponse class.
        /// </summary>
        public IndexResponse(IList<ResponseIndex> indexes = default(IList<ResponseIndex>))
        {
            Indexes = indexes;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "indexes")]
        public IList<ResponseIndex> Indexes { get; set; }

    }
}
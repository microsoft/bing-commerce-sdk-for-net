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

    public partial class RequestClient
    {
        /// <summary>
        /// Initializes a new instance of the RequestClient class.
        /// </summary>
        public RequestClient()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RequestClient class.
        /// </summary>
        public RequestClient(IList<RequestClientId> ids = default(IList<RequestClientId>))
        {
            Ids = ids;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        public IList<RequestClientId> Ids { get; set; }

    }
}
// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ECommerce.Search.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class GeoCondition : ConditionBase
    {
        /// <summary>
        /// Initializes a new instance of the GeoCondition class.
        /// </summary>
        public GeoCondition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GeoCondition class.
        /// </summary>
        public GeoCondition(GeoBoundaryBase boundary = default(GeoBoundaryBase))
        {
            Boundary = boundary;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "boundary")]
        public GeoBoundaryBase Boundary { get; set; }

    }
}

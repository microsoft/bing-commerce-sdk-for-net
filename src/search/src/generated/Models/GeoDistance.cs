// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ECommerce.Search.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class GeoDistance : GeoBoundaryBase
    {
        /// <summary>
        /// Initializes a new instance of the GeoDistance class.
        /// </summary>
        public GeoDistance()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GeoDistance class.
        /// </summary>
        public GeoDistance(GeoPoint center = default(GeoPoint), double? radius = default(double?))
        {
            Center = center;
            Radius = radius;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "center")]
        public GeoPoint Center { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "radius")]
        public double? Radius { get; set; }

    }
}

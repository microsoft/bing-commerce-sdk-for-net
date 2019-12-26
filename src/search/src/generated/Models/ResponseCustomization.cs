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

    [Newtonsoft.Json.JsonObject("Response.Customization")]
    public partial class ResponseCustomization : ResponseTask
    {
        /// <summary>
        /// Initializes a new instance of the ResponseCustomization class.
        /// </summary>
        public ResponseCustomization()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ResponseCustomization class.
        /// </summary>
        public ResponseCustomization(IList<ResponseError> errors = default(IList<ResponseError>), IList<ResponseDebugInfo> debug = default(IList<ResponseDebugInfo>), bool? queryAlteration = default(bool?), IList<Synonym> synonyms = default(IList<Synonym>), IList<string> rules = default(IList<string>), ConditionBase filter = default(ConditionBase), IList<ResponseBoostExpression> boosts = default(IList<ResponseBoostExpression>))
            : base(errors, debug)
        {
            QueryAlteration = queryAlteration;
            Synonyms = synonyms;
            Rules = rules;
            Filter = filter;
            Boosts = boosts;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "queryAlteration")]
        public bool? QueryAlteration { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "synonyms")]
        public IList<Synonym> Synonyms { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rules")]
        public IList<string> Rules { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "filter")]
        public ConditionBase Filter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "boosts")]
        public IList<ResponseBoostExpression> Boosts { get; set; }

    }
}

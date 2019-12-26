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

    public partial class RequestQuery
    {
        /// <summary>
        /// Initializes a new instance of the RequestQuery class.
        /// </summary>
        public RequestQuery()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RequestQuery class.
        /// </summary>
        public RequestQuery(string matchAll = default(string), RequestQueryClauseBase value = default(RequestQueryClauseBase), ConditionBase filter = default(ConditionBase), IList<RequestBoostExpression> boosts = default(IList<RequestBoostExpression>), bool? alteration = default(bool?), IList<Synonym> synonyms = default(IList<Synonym>))
        {
            MatchAll = matchAll;
            Value = value;
            Filter = filter;
            Boosts = boosts;
            Alteration = alteration;
            Synonyms = synonyms;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "matchAll")]
        public string MatchAll { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public RequestQueryClauseBase Value { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "filter")]
        public ConditionBase Filter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "boosts")]
        public IList<RequestBoostExpression> Boosts { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "alteration")]
        public bool? Alteration { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "synonyms")]
        public IList<Synonym> Synonyms { get; set; }

    }
}
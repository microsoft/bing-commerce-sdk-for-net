// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.Commerce.Search.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the customizations applied to the search operation.
    /// </summary>
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
        /// <param name="errors">A list of errors that happened to the task, if
        /// any.</param>
        /// <param name="queryAlteration">A boolean to determine if query
        /// alteration have been applied to the search operation.</param>
        /// <param name="synonyms">The synonyms used to apply the search
        /// query.</param>
        /// <param name="filter">The filters applied to the search
        /// result.</param>
        /// <param name="boosts">The boost expressions applied to the search
        /// result.</param>
        public ResponseCustomization(IList<ResponseError> errors = default(IList<ResponseError>), IList<ResponseDebugInfo> debug = default(IList<ResponseDebugInfo>), bool? queryAlteration = default(bool?), IList<Synonym> synonyms = default(IList<Synonym>), IList<string> rules = default(IList<string>), ConditionBase filter = default(ConditionBase), IList<BoostExpression> boosts = default(IList<BoostExpression>))
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
        /// Gets or sets a boolean to determine if query alteration have been
        /// applied to the search operation.
        /// </summary>
        [JsonProperty(PropertyName = "queryAlteration")]
        public bool? QueryAlteration { get; set; }

        /// <summary>
        /// Gets or sets the synonyms used to apply the search query.
        /// </summary>
        [JsonProperty(PropertyName = "synonyms")]
        public IList<Synonym> Synonyms { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rules")]
        public IList<string> Rules { get; set; }

        /// <summary>
        /// Gets or sets the filters applied to the search result.
        /// </summary>
        [JsonProperty(PropertyName = "filter")]
        public ConditionBase Filter { get; set; }

        /// <summary>
        /// Gets or sets the boost expressions applied to the search result.
        /// </summary>
        [JsonProperty(PropertyName = "boosts")]
        public IList<BoostExpression> Boosts { get; set; }

    }
}

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
    using System.Linq;

    /// <summary>
    /// Defines a type of query to search specific fields.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Match")]
    public partial class RequestMatch : RequestQueryClauseBase
    {
        /// <summary>
        /// Initializes a new instance of the RequestMatch class.
        /// </summary>
        public RequestMatch()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RequestMatch class.
        /// </summary>
        /// <param name="value">The search terms to match on the specified
        /// fields.</param>
        public RequestMatch(string value = default(string))
        {
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the search terms to match on the specified fields.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}

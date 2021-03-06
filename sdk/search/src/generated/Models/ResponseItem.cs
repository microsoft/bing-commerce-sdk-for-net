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
    /// Defines an item from your content catalog.
    /// </summary>
    public partial class ResponseItem
    {
        /// <summary>
        /// Initializes a new instance of the ResponseItem class.
        /// </summary>
        public ResponseItem()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ResponseItem class.
        /// </summary>
        /// <param name="indexId">The ID of the index the item belongs
        /// to.</param>
        /// <param name="itemId">An ID that uniquely identifies an item within
        /// the index.</param>
        /// <param name="score">A value that indicates how well the item
        /// matches the query. Higher values indicate a closer match.</param>
        /// <param name="fields">An object with the selected fields as
        /// properties.</param>
        public ResponseItem(string indexId = default(string), string itemId = default(string), double? score = default(double?), object fields = default(object), IList<ResponseDebugInfo> debug = default(IList<ResponseDebugInfo>))
        {
            IndexId = indexId;
            ItemId = itemId;
            Score = score;
            Fields = fields;
            Debug = debug;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the ID of the index the item belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "indexId")]
        public string IndexId { get; set; }

        /// <summary>
        /// Gets or sets an ID that uniquely identifies an item within the
        /// index.
        /// </summary>
        [JsonProperty(PropertyName = "itemId")]
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates how well the item matches the
        /// query. Higher values indicate a closer match.
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public double? Score { get; set; }

        /// <summary>
        /// Gets or sets an object with the selected fields as properties.
        /// </summary>
        [JsonProperty(PropertyName = "fields")]
        public object Fields { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "debug")]
        public IList<ResponseDebugInfo> Debug { get; set; }

    }
}

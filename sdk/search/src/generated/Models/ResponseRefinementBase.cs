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
    /// Defines the abstract base type for refinement based aggregation.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Response.RefinementBase")]
    public partial class ResponseRefinementBase : ResponseAggregation
    {
        /// <summary>
        /// Initializes a new instance of the ResponseRefinementBase class.
        /// </summary>
        public ResponseRefinementBase()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ResponseRefinementBase class.
        /// </summary>
        /// <param name="errors">A list of errors that happened to the task, if
        /// any.</param>
        /// <param name="name">The aggregation name as defined in the
        /// requset.</param>
        /// <param name="estimatedCount">An estimated count of items in this
        /// aggregation.</param>
        /// <param name="aggregations">The list of child aggregations, if
        /// any.</param>
        /// <param name="label">The label to use for the aggregation, that you
        /// can use to render your UI.</param>
        public ResponseRefinementBase(IList<ResponseError> errors = default(IList<ResponseError>), IList<ResponseDebugInfo> debug = default(IList<ResponseDebugInfo>), string name = default(string), long? estimatedCount = default(long?), IList<ResponseAggregation> aggregations = default(IList<ResponseAggregation>), string label = default(string))
            : base(errors, debug, name, estimatedCount, aggregations)
        {
            Label = label;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the label to use for the aggregation, that you can use
        /// to render your UI.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

    }
}
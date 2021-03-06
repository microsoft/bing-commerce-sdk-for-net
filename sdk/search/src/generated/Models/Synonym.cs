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
    /// Defines a set of alternate terms (or phrases) that can be applied to
    /// request query.
    /// </summary>
    public partial class Synonym
    {
        /// <summary>
        /// Initializes a new instance of the Synonym class.
        /// </summary>
        public Synonym()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Synonym class.
        /// </summary>
        /// <param name="synonymId">The id for the saved synonym.</param>
        /// <param name="synonyms">The alternate terms to apply</param>
        public Synonym(string synonymId = default(string), IList<string> synonyms = default(IList<string>))
        {
            SynonymId = synonymId;
            Synonyms = synonyms;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the id for the saved synonym.
        /// </summary>
        [JsonProperty(PropertyName = "synonymId")]
        public string SynonymId { get; set; }

        /// <summary>
        /// Gets or sets the alternate terms to apply
        /// </summary>
        [JsonProperty(PropertyName = "synonyms")]
        public IList<string> Synonyms { get; set; }

    }
}

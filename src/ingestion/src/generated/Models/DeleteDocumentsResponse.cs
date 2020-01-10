// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.Commerce.Ingestion.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A response containing the status for a request to delete documents from
    /// the index.
    /// </summary>
    public partial class DeleteDocumentsResponse
    {
        /// <summary>
        /// Initializes a new instance of the DeleteDocumentsResponse class.
        /// </summary>
        public DeleteDocumentsResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DeleteDocumentsResponse class.
        /// </summary>
        /// <param name="status">The status for the document deletion request.
        /// Possible values include: 'Succeeded', 'PartiallySucceeded',
        /// 'Failed'</param>
        /// <param name="errorMessage">An aggregation of error messages for
        /// errors that happened while processing the request, if any.</param>
        /// <param name="result">A list of status results per document.</param>
        public DeleteDocumentsResponse(string status = default(string), string errorMessage = default(string), IList<ResponseDocumentDeletionResult> result = default(IList<ResponseDocumentDeletionResult>))
        {
            Status = status;
            ErrorMessage = errorMessage;
            Result = result;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the status for the document deletion request. Possible
        /// values include: 'Succeeded', 'PartiallySucceeded', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets an aggregation of error messages for errors that
        /// happened while processing the request, if any.
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a list of status results per document.
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public IList<ResponseDocumentDeletionResult> Result { get; set; }

    }
}

// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ECommerce.Search.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ResponseError
    {
        /// <summary>
        /// Initializes a new instance of the ResponseError class.
        /// </summary>
        public ResponseError()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ResponseError class.
        /// </summary>
        /// <param name="code">Possible values include: 'None', 'ServerError',
        /// 'InvalidRequest', 'InsufficientAuthorization'</param>
        /// <param name="subCode">Possible values include: 'UnexpectedError',
        /// 'ResourceError', 'DeadlineExceeded', 'ParameterMissing',
        /// 'ParameterInvalidValue'</param>
        public ResponseError(string code = default(string), string subCode = default(string), string message = default(string), string moreDetails = default(string))
        {
            Code = code;
            SubCode = subCode;
            Message = message;
            MoreDetails = moreDetails;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets possible values include: 'None', 'ServerError',
        /// 'InvalidRequest', 'InsufficientAuthorization'
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'UnexpectedError',
        /// 'ResourceError', 'DeadlineExceeded', 'ParameterMissing',
        /// 'ParameterInvalidValue'
        /// </summary>
        [JsonProperty(PropertyName = "subCode")]
        public string SubCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moreDetails")]
        public string MoreDetails { get; set; }

    }
}

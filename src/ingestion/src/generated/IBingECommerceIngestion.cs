// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ECommerce.Ingestion
{
    using Microsoft.Rest;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// </summary>
    public partial interface IBingECommerceIngestion : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Subscription credentials which uniquely identify client
        /// subscription.
        /// </summary>
        ServiceClientCredentials Credentials { get; }


        /// <param name='tenantid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='body'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IndexResponse>> CreateIndexWithHttpMessagesAsync(string tenantid, string subscriptionId = default(string), Index body = default(Index), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='tenantid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IndexResponse>> GetAllIndexesWithHttpMessagesAsync(string tenantid, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='tenantid'>
        /// </param>
        /// <param name='indexid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IndexResponse>> DeleteIndexWithHttpMessagesAsync(string tenantid, string indexid, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='tenantid'>
        /// </param>
        /// <param name='indexid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='body'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IndexResponse>> UpdateIndexWithHttpMessagesAsync(string tenantid, string indexid, string subscriptionId = default(string), Index body = default(Index), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='tenantid'>
        /// </param>
        /// <param name='indexid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IndexResponse>> GetIndexWithHttpMessagesAsync(string tenantid, string indexid, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='tenantid'>
        /// </param>
        /// <param name='indexid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IndexStatusResponse>> GetIndexStatusWithHttpMessagesAsync(string tenantid, string indexid, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='body'>
        /// </param>
        /// <param name='tenantid'>
        /// </param>
        /// <param name='indexid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='notransform'>
        /// </param>
        /// <param name='updateid'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<PushDataUpdateResponse>> PushDataUpdateWithHttpMessagesAsync(string body, string tenantid, string indexid, string subscriptionId = default(string), bool? notransform = default(bool?), string updateid = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='tenantid'>
        /// </param>
        /// <param name='indexid'>
        /// </param>
        /// <param name='updateid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<PushUpdateStatusResponse>> PushDataStatusWithHttpMessagesAsync(string tenantid, string indexid, string updateid, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='tenantid'>
        /// </param>
        /// <param name='indexid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<TransformationConfigResponse>> DeleteTransformationConfigWithHttpMessagesAsync(string tenantid, string indexid, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='body'>
        /// </param>
        /// <param name='tenantid'>
        /// </param>
        /// <param name='indexid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<TransformationConfigResponse>> CreateOrUpdateTransformationConfigWithHttpMessagesAsync(string body, string tenantid, string indexid, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='tenantid'>
        /// </param>
        /// <param name='indexid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<TransformationConfigResponse>> GetTransformationConfigWithHttpMessagesAsync(string tenantid, string indexid, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='body'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<TransformationConfigResponse>> UploadTryOutConfigWithHttpMessagesAsync(string body, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='tryoutid'>
        /// </param>
        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<TransformationTryoutResponse>> ExecuteTryOutConfigWithHttpMessagesAsync(string tryoutid, string subscriptionId = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='format'>
        /// Possible values include: 'Unknown', 'LDJson', 'CSV', 'TSV',
        /// 'JsonArray'
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<SchemaDetectionResponse>> DetectSchemaWithHttpMessagesAsync(string subscriptionId = default(string), string format = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

    }
}

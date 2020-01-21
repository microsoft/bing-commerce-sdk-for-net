// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.Commerce.Search
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// SearchOperations operations.
    /// </summary>
    public partial interface ISearchOperations
    {
        /// <summary>
        /// Bing Commerce Custom Search Query.
        /// </summary>
        /// <remarks>
        /// POST requests accept complex search request options.
        /// </remarks>
        /// <param name='body'>
        /// </param>
        /// <param name='tenant'>
        /// </param>
        /// <param name='index'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<CommerceSearchResponse>> PostWithHttpMessagesAsync(CommerceSearchPostRequest body, string tenant, string index, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Bing Commerce Basic Search Query.
        /// </summary>
        /// <remarks>
        /// GET requests can search an index using only URL parameters. Only
        /// limited request options are available. GET requests will always do
        /// simple item search and support only a default facet discovery
        /// aggregation.
        /// </remarks>
        /// <param name='q'>
        /// The query to match against all eligible fields.
        /// </param>
        /// <param name='tenant'>
        /// </param>
        /// <param name='index'>
        /// </param>
        /// <param name='mkt'>
        /// The market where the results come from. Thypically, `mkt` is the
        /// country where the user is making the request from.
        /// </param>
        /// <param name='setlang'>
        /// The language to use for user interface strings. You may specify the
        /// language using either a 2-letter or 4-letter code. Using 4-letter
        /// codes is preferred.
        /// </param>
        /// <param name='select'>
        /// A comma-separated list of fields to return. unspecified or empty to
        /// select only _itemId, or `*` to select all fields.
        /// </param>
        /// <param name='orderby'>
        /// A comma-separated list of OData order syntax expressions.
        /// </param>
        /// <param name='top'>
        /// The maximum count of items to return for pagination. Default is 24.
        /// </param>
        /// <param name='skip'>
        /// The offset to the first item to return for pagination. Default is
        /// 0.
        /// </param>
        /// <param name='discoverfacets'>
        /// Default value is false. When true, requests a facet discovery
        /// aggregation.
        /// </param>
        /// <param name='alteration'>
        /// A boolean flag to enable or disable query alteration. Default is
        /// true.
        /// </param>
        /// <param name='debug'>
        /// </param>
        /// <param name='searchinstanceid'>
        /// A saved search instance configuration to apply to current request.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<CommerceSearchResponse>> GetWithHttpMessagesAsync(string q, string tenant, string index, string mkt = default(string), string setlang = default(string), string select = default(string), string orderby = default(string), int? top = default(int?), int? skip = default(int?), bool? discoverfacets = false, bool? alteration = true, bool? debug = false, string searchinstanceid = "Default", Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
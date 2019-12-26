// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ECommerce.Search
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for SearchOperations.
    /// </summary>
    public static partial class SearchOperationsExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='tenant'>
            /// </param>
            /// <param name='index'>
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ECommerceSearchResponse> PostAsync(this ISearchOperations operations, string tenant, string index, ECommerceSearchPostRequest body = default(ECommerceSearchPostRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostWithHttpMessagesAsync(tenant, index, body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='tenant'>
            /// </param>
            /// <param name='index'>
            /// </param>
            /// <param name='mkt'>
            /// </param>
            /// <param name='setlang'>
            /// </param>
            /// <param name='q'>
            /// </param>
            /// <param name='select'>
            /// </param>
            /// <param name='orderby'>
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='discoverfacets'>
            /// </param>
            /// <param name='alteration'>
            /// </param>
            /// <param name='debug'>
            /// </param>
            /// <param name='searchinstanceid'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ECommerceSearchResponse> GetAsync(this ISearchOperations operations, string tenant, string index, string mkt = default(string), string setlang = default(string), string q = default(string), string select = default(string), string orderby = default(string), int? top = default(int?), int? skip = default(int?), bool? discoverfacets = false, bool? alteration = true, bool? debug = false, string searchinstanceid = "Default", CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(tenant, index, mkt, setlang, q, select, orderby, top, skip, discoverfacets, alteration, debug, searchinstanceid, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}

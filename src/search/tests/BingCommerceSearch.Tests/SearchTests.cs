// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchTests.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Bing.Commerce.Search.Tests
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.Bing.Commerce.Search.Models;
    using Microsoft.Rest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    [TestClass]
    public class SearchTests
    {

        private static readonly ServiceClientCredentials Credentials = new AppIdCredentials(Environment.GetEnvironmentVariable("SEARCH_APPID"));
        private static readonly string TenantId =  Environment.GetEnvironmentVariable("SEARCH_TENANT");
        private static readonly string IndexId = Environment.GetEnvironmentVariable("SEARCH_INDEX");

        [TestMethod]
        public async Task Search_MatchItems()
        {
            var brs = new BingCommerceSearch(Credentials, new TestTrafficHandler());

            var request = new CommerceSearchPostRequest()
            {
                Query = new RequestQuery() { MatchAll = "diamond" },
                Items = new RequestItems()
                {
                    Select = new[] { "_itemId", "name" }
                }
            };

            var response = await brs.Search.PostAsync(request, TenantId, IndexId);
            Assert.IsNotNull(response, "Expected non-null response");

            var items = response.Items as ResponseItems;
            Assert.IsNotNull(items, "Expected non-null items response");
            Assert.IsNotNull(items.TotalEstimatedMatches, "Expected items.totalEstimatedMatches");
            Assert.IsNotNull(items.Value, "Expected non-null items.value");

            Assert.AreNotEqual(0, items.TotalEstimatedMatches, "Expected non-zero items.totalEstimatedMatches");
            Assert.AreNotEqual(0, items.Value.Count, "Expected at least one item");

            for (var i = 0; i < items.Value.Count; i++)
            {
                var item = items.Value[i];
                Assert.IsNotNull(item?.ItemId, "Expected non-null item with an item ID at position " + i);

                var fields = item.Fields as JObject;
                Assert.IsNotNull(fields, "Expected item fields to be a JObject at position " + i);

                var title = fields.Value<string>("name");
                Assert.IsNotNull(title, "Expected item to have a title at position " + i);
            }
        }

        [TestMethod]
        public async Task Search_DiscoverFacets()
        {
            var brs = new BingCommerceSearch(Credentials, new TestTrafficHandler());

            var request = new CommerceSearchPostRequest()
            {
                Query = new RequestQuery() { MatchAll = "diamond" },
                Items = new RequestItems(),
                Aggregations = new RequestAggregationBase[]
                {
                    new RequestDiscoverFacets("discovered facets"), 
                }
            };

            var response = await brs.Search.PostAsync(request, TenantId, IndexId);
            Assert.IsNotNull(response, "Expected non-null response");

            var items = response.Items as ResponseItems;
            Assert.IsNotNull(items, "Expected non-null items response");
            Assert.IsNotNull(items.Value, "Expected non-null items.value");

            Assert.AreEqual(1, response.Aggregations?.Count ?? 0, "Expected 1 aggregation in the response");
            var discoveredFacets = response.Aggregations[0] as ResponseDiscoveredFacets;
            Assert.IsNotNull(discoveredFacets, "Expected discovered facets response");
            Assert.AreEqual(discoveredFacets.Name, request.Aggregations[0].Name, "Expected facet response name to match the request");

            Assert.AreNotEqual(0, discoveredFacets.Aggregations?.Count ?? 0, "Expected at least 1 discovered facet");
        }

        public class TestTrafficHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var builder = new UriBuilder(request.RequestUri);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["traffictype"] = "test";
                builder.Query = query.ToString();
                request.RequestUri = builder.Uri;

                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}
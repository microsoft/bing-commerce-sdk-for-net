namespace Microsoft.BingECommerce.Ingestion.Tests
{
    using Microsoft.Bing.ECommerce.Ingestion;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Bing.ECommerce.Ingestion.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System;

    [TestClass]
    public class TestIngestion
    {
        private static readonly AppIdCredentials Credentials = new AppIdCredentials(
            Environment.GetEnvironmentVariable("INGEST_APPID"));
        private static readonly string TENANT_ID = Environment.GetEnvironmentVariable("INGEST_TENANT");
        private static readonly string TEST_INDEX_NAME = "testIndex01234";

        [TestCleanup]
        public async Task Cleanup()
        {
            var client = CreateClient();
            var allIndexes = await client.GetAllIndexesAsync(TENANT_ID);

            foreach (var index in allIndexes.Indexes)
            {
                if (index.Name == TEST_INDEX_NAME)
                {
                    await client.DeleteIndexAsync(TENANT_ID, index.Id);
                }
            }
        }


        [TestMethod]
        public async Task TestIndexes()
        {
            // First, make sure we don't have an index with the test name.
            Cleanup();
            var client = CreateClient();

            // Create an index
            var field = new IndexField()
            {
                Name = "testField01234",
                Type = IndexFieldType.ProductId
            };
            var newIndexReq = new Index()
            {
                Name = TEST_INDEX_NAME,
                Description = "Created with the csharp unit testing",
                Fields = new List<IndexField>() { field }
            };
            var createResponse = await client.CreateIndexAsync(TENANT_ID, body: newIndexReq);
            Assert.IsNotNull(createResponse, "Expected non-null response.");
            Assert.IsNotNull(createResponse.Indexes, "Expected non-null indexes response.");
            Assert.AreEqual(1, createResponse.Indexes.Count);

            // Get all indexes
            var allIndexes = await client.GetAllIndexesAsync(TENANT_ID);
            Assert.IsNotNull(allIndexes, "Expected non-null response");
            Assert.IsNotNull(allIndexes.Indexes, "Expected non-null indexes response.");
            Assert.AreNotEqual(0, allIndexes.Indexes.Count);

            // Get specific index
            var getIndexResponse = await client.GetIndexAsync(TENANT_ID, createResponse.Indexes[0].Id);
            Assert.IsNotNull(getIndexResponse, "Expected non-null response.");
            Assert.IsNotNull(getIndexResponse.Indexes, "Expected non-null indexes response.");
            Assert.AreEqual(1, getIndexResponse.Indexes.Count);

            // Update Index
            var extraField = new IndexField()
            {
                Name = "extraTestField01234",
                Type = IndexFieldType.Number
            };
            newIndexReq.Fields = new List<IndexField>() { field, extraField};
            var updateResponse = await client.UpdateIndexAsync(TENANT_ID, createResponse.Indexes[0].Id, body: newIndexReq);
            Assert.IsNotNull(updateResponse, "Expected non-null response.");
            Assert.IsNotNull(updateResponse.Indexes, "Expected non-null indexes response.");
            Assert.AreEqual(1, updateResponse.Indexes.Count);
            Assert.AreEqual(2, updateResponse.Indexes[0].Fields.Count);

            // Index Status
            var indexStatus = await client.GetIndexStatusAsync(TENANT_ID, createResponse.Indexes[0].Id);
            Assert.IsNotNull(indexStatus, "Expected non-null response.");
            Assert.IsNotNull(indexStatus.IndexStatuses, "Expected non-null statuses response.");
            Assert.AreEqual(1, indexStatus.IndexStatuses.Count);

            // Delete Index
            var deleteResponse = await client.DeleteIndexAsync(TENANT_ID, createResponse.Indexes[0].Id);
            Assert.IsNotNull(deleteResponse, "Expected non-null response.");
            Assert.IsNotNull(deleteResponse.Indexes, "Expected non-null indexes response.");
            Assert.AreEqual(1, deleteResponse.Indexes.Count);
        }

        [TestMethod]
        public async Task TestPush()
        {
            var client = CreateClient();

            var indexId = await EnsureTestIndex(client);

            var pushResponse = await client.PushDataUpdateAsync("Test Content", TENANT_ID, indexId);
            Assert.IsNotNull(pushResponse, "Expected non-null response");
            Assert.IsNotNull(pushResponse.UpdateId, "Expected non-null update id");

            var statusResposne = await client.PushDataStatusAsync(TENANT_ID, indexId, pushResponse.UpdateId);
            Assert.IsNotNull(statusResposne, "Expected non-null response");
            Assert.IsNotNull(statusResposne.Status, "Expected non-null status");
        }

        private async Task<string> EnsureTestIndex(BingECommerceIngestion client)
        {
            var allIndexes = await client.GetAllIndexesAsync(TENANT_ID);

            foreach (var index in allIndexes.Indexes)
            {
                if (index.Name == TEST_INDEX_NAME)
                {
                    return index.Id;
                }
            }

            var field = new IndexField()
            {
                Name = "testField01234",
                Type = IndexFieldType.ProductId
            };
            var newIndexReq = new Index()
            {
                Name = TEST_INDEX_NAME,
                Description = "Created with the csharp unit testing",
                Fields = new List<IndexField>() { field }
            };
            var createResponse = await client.CreateIndexAsync(TENANT_ID, body: newIndexReq);

            return createResponse.Indexes[0].Id;

        }

        private BingECommerceIngestion CreateClient()
        {
            return new BingECommerceIngestion(Credentials, new TestTrafficHandler());
        }

        public class TestTrafficHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var builder = new System.UriBuilder(request.RequestUri);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["traffictype"] = "test";
                builder.Query = query.ToString();
                request.RequestUri = builder.Uri;

                return await base.SendAsync(request, cancellationToken);
            }
        }

    }
}
